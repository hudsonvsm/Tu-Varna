package com.vale.warehouses.app.service;

import com.vale.warehouses.app.service.interfaces.OwnerInterface;
import com.vale.warehouses.app.service.interfaces.SaleAgentInterface;
import com.vale.warehouses.app.service.interfaces.TenantInterface;
import com.vale.warehouses.app.service.interfaces.UserServiceInterface;
import com.vale.warehouses.auth.models.UserEntity;
import com.vale.warehouses.auth.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Optional;

@Service
@Transactional
public class AdminUserService implements UserServiceInterface {
    @Autowired
    private UserRepository userRepository;

    @Autowired
    private BCryptPasswordEncoder bCryptPasswordEncoder;

    @Autowired
    private OwnerInterface ownerService;

    @Autowired
    private SaleAgentInterface saleAgentService;

    @Autowired
    private TenantInterface tenantService;

    @Override
    public List<UserEntity> getUsers()
    {
        List<UserEntity> employeeList = userRepository.findAll();

        if(employeeList.size() > 0) {
            return employeeList;
        } else {
            return new ArrayList<>();
        }
    }

    @Override
    public UserEntity getUser(Long id) throws NullPointerException
    {
        Optional<UserEntity> user = userRepository.findById(id);

        if(!user.isPresent()) {
            throw new NullPointerException("No user record exist for given id");
        }

        return user.get();
    }

    @Override
    public UserEntity createUser(UserEntity entity)
    {
        if(!Objects.isNull(entity.getId()) && userRepository.existsById(entity.getId()))
        {
            throw new IllegalArgumentException("User with that ID already exists");
        }

        if (!entity.getPassword().equals(entity.getPasswordConfirm())) {
            throw new IllegalArgumentException("PAss and pass confirm doesn't match");
        }

        if (entity.getRoles().isEmpty()) {
            throw new IllegalArgumentException("User need at least 1 role");
        }

        entity.setPassword(bCryptPasswordEncoder.encode(entity.getPassword()));
        entity.setPasswordConfirm("");

        if (entity.getRelatedOwner() != null) {
            ownerService.createOwner(entity.getRelatedOwner());
        }
        else if(entity.getRelatedSaleAgent() != null) {
            saleAgentService.createSaleAgent(entity.getRelatedSaleAgent());
        }
        else if(entity.getRelatedTenant() != null) {
            tenantService.createTenant(entity.getRelatedTenant());
        }

        return userRepository.save(entity);
    }

    @Override
    public UserEntity updateUser(Long id, UserEntity entity) throws NullPointerException
    {
        Optional<UserEntity> user = userRepository.findById(id);

        if(!user.isPresent())
        {
            throw new NullPointerException("No user with that ID");
        }

        if (entity.getRelatedOwner() != null) {
            ownerService.updateOwner(entity.getRelatedOwner());
        }
        else if(entity.getRelatedSaleAgent() != null) {
            saleAgentService.updateSaleAgent(entity.getRelatedSaleAgent());
        }
        else if(entity.getRelatedTenant() != null) {
            tenantService.updateTenant(entity.getRelatedTenant());
        }

        UserEntity newEntity = user.get();
        newEntity.setEmail(entity.getEmail());
        newEntity.setRoles(entity.getRoles());
        newEntity.setRelatedOwner(entity.getRelatedOwner());
        newEntity.setRelatedSaleAgent(entity.getRelatedSaleAgent());
        newEntity.setRelatedTenant(entity.getRelatedTenant());

        //TODO Update password

        return userRepository.save(newEntity);
    }

    @Override
    public void deleteUser(Long id) throws NullPointerException
    {
        Optional<UserEntity> user = userRepository.findById(id);

        if(!user.isPresent())
        {
            throw new NullPointerException("No user record exist for given id");
        }

        userRepository.deleteById(id);
    }

    @Override
    public UserEntity findByUsername(String username) {
        return userRepository.findByUsername(username);
    }
}
