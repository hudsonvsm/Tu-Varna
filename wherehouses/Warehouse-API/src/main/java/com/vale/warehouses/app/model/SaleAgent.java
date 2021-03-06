package com.vale.warehouses.app.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.vale.warehouses.auth.models.UserEntity;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name="sale_agent")
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
public class SaleAgent extends AbstractPerson {
    private int rating;

    private BigDecimal fee;

    @ManyToMany(mappedBy = "saleAgents")
    private Set<Warehouse> warehouses = new HashSet<>();

    @OneToMany(
            cascade = CascadeType.ALL,
            fetch = FetchType.LAZY,
            orphanRemoval = true
    )
    private Set<LeasingContract> leasingContracts = new HashSet<>();

    @OneToOne(fetch = FetchType.LAZY,
            cascade = CascadeType.ALL,
            mappedBy = "relatedSaleAgent",
            optional = true)
    @PrimaryKeyJoinColumn
    @JsonIgnore
    private UserEntity user;

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public BigDecimal getFee() {
        return fee;
    }

    public void setFee(BigDecimal fee) {
        this.fee = fee;
    }

    public Set<Warehouse> getWarehouses() {
        return warehouses;
    }

    public void setWarehouses(Set<Warehouse> warehouses) {
        this.warehouses = warehouses;
    }

    public Set<LeasingContract> getLeasingContracts() {
        return leasingContracts;
    }

    public void setLeasingContracts(Set<LeasingContract> leasingContracts) {
        this.leasingContracts = leasingContracts;
    }

    public UserEntity getUser() {
        return user;
    }

    public void setUser(UserEntity user) {
        this.user = user;
    }
}
