package com.vale.warehouses.integration_tests;

import com.google.gson.reflect.TypeToken;
import com.vale.warehouses.Start;
import com.vale.warehouses.auth.models.RoleEntity;
import com.vale.warehouses.auth.models.TokenEntity;
import com.vale.warehouses.auth.repository.RoleRepository;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.ResultActions;

import java.lang.reflect.Type;
import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;
import static org.hamcrest.Matchers.greaterThanOrEqualTo;
import static org.hamcrest.Matchers.hasSize;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@RunWith(SpringRunner.class)
@SpringBootTest(webEnvironment= SpringBootTest.WebEnvironment.RANDOM_PORT, classes= Start.class)

public class RoleControllerIntegrationTest extends BaseIntegrationTest {
    @Autowired
    private RoleRepository roleRepository;

    @After
    public void resetDb() {
//        tokenRepository.deleteAll();
//
//        List<UserEntity> a = repository.findAll();
//        a.forEach(ala -> ala.setRoles(new HashSet<>()));
//        repository.saveAll(a);
//        repository.saveAndFlush(a1.get(0));
//
//        repository.deleteAll();
//        roleRepository.deleteAll();
//        List<UserEntity> a1 = repository.findAll();
//        List<RoleEntity> r1 = roleRepository.findAll();
    }

    @Before
    public void setUp() {
        List<RoleEntity> roleEntities = roleRepository.findAll();

        if(roleEntities.size() > 0) {
            return;
        }

        baseRolesAndUsersSetup();
    }

    @Test
    public void givenAdminUser_whenGetRoles_thenStatus200() throws Exception {
        TokenEntity token = this.userLogin("admin", "123456");

        ResultActions result = mvc.perform(get("/api/role")
                .contentType(MediaType.APPLICATION_JSON)
                .header("Authorization", "Bearer " + token.getId()))
                .andDo(print())
                .andExpect(status().isOk())
                .andExpect(content().contentTypeCompatibleWith(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$", hasSize(greaterThanOrEqualTo(2))));

        String resultString = result.andReturn().getResponse().getContentAsString();

        Type listType = new TypeToken<List<RoleEntity>>(){}.getType();
        List<RoleEntity> roleEntities = buildGson().fromJson(resultString, listType);
        assertThat(roleEntities).isNotNull();

        List<RoleEntity> roleDbEntities = roleRepository.findAll();

        assertThat(roleDbEntities).isNotNull();
        assertThat(roleEntities).hasSize(roleDbEntities.size());
    }

    @Test
    public void givenNotAdminUser_whenGetRoles_thenStatus403() throws Exception {
        TokenEntity token = this.userLogin("owner", "123456");

        ResultActions result = mvc.perform(get("/api/role")
                .contentType(MediaType.APPLICATION_JSON)
                .header("Authorization", "Bearer " + token.getId()))
                .andDo(print())
                .andExpect(status().is4xxClientError());

        String resultString = result.andReturn().getResponse().getContentAsString();
        assertThat(resultString).isNullOrEmpty();
    }
}
