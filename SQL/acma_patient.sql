CREATE TABLE ACMA_PATIENT (
    patient_id number not null,
    fullname varchar2(255) not null,
    nic varchar2(15) not null,
    telephone number(10),
    address varchar2(255),
    primary key (patient_id),
    UNIQUE (nic)
);
