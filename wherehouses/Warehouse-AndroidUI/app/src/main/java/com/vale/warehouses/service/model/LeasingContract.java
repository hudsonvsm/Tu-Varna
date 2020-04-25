package com.vale.warehouses.service.model;

import com.google.gson.annotations.SerializedName;

import java.time.OffsetDateTime;

public class LeasingContract {
    @SerializedName("id")
    private Long id;

    @SerializedName("leasedAt")
    private OffsetDateTime leasedAt;

    @SerializedName("leasedTill")
    private OffsetDateTime leasedTill;

    @SerializedName("warehouse")
    private Warehouse warehouse;

    @SerializedName("saleAgent")
    private SaleAgent saleAgent;

    @SerializedName("tenant")
    private Tenant tenant;

    @SerializedName("owner")
    private Owner owner;

    @SerializedName("leaseRequest")
    private LeaseRequest leaseRequest;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public OffsetDateTime getLeasedAt() {
        return leasedAt;
    }

    public void setLeasedAt(OffsetDateTime leasedAt) {
        this.leasedAt = leasedAt;
    }

    public OffsetDateTime getLeasedTill() {
        return leasedTill;
    }

    public void setLeasedTill(OffsetDateTime leasedTill) {
        this.leasedTill = leasedTill;
    }

    public Warehouse getWarehouse() {
        return warehouse;
    }

    public void setWarehouse(Warehouse warehouse) {
        this.warehouse = warehouse;
    }

    public SaleAgent getSaleAgent() {
        return saleAgent;
    }

    public void setSaleAgent(SaleAgent saleAgent) {
        this.saleAgent = saleAgent;
    }

    public Tenant getTenant() {
        return tenant;
    }

    public void setTenant(Tenant tenant) {
        this.tenant = tenant;
    }

    public Owner getOwner() {
        return owner;
    }

    public void setOwner(Owner owner) {
        this.owner = owner;
    }

    public LeaseRequest getLeaseRequest() {
        return leaseRequest;
    }

    public void setLeaseRequest(LeaseRequest leaseRequest) {
        this.leaseRequest = leaseRequest;
    }
}