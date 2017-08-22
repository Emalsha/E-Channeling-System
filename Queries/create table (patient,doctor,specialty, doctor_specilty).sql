CREATE TABLE ACMA_PATIENT (
    patient_id number not null,
    fullname varchar2(255) not null,
    nic varchar2(15) not null,
    telephone number(10),
    address varchar2(255),
    primary key (patient_id),
    UNIQUE (nic)
);

CREATE TABLE ACMA_DOCTOR (
    doctor_id number not null,
    fullname varchar2(255)  not null,
    telephone number(10),
    address varchar2(255),
    nic varchar2(15)  not null,
    available_on_weekend number (1,0),
    patient_per_day number,
    time_per_patient number,
    room_number varchar2(8),
    username varchar2 (64),
    password varchar2 (64),
    email varchar2 (64),
    primary key (doctor_id),
    UNIQUE (nic)
); 

CREATE TABLE ACMA_SPECIALTY (
    specialty_id number not null,
    description varchar2(512),
    primary key (specialty_id)
);

CREATE TABLE ACMA_DOCTOR_SPECIALTY (
    doctor_specialty_id number not null,
    doctor_id number not null,
    specialty_id number not null,
    primary key (specialty_id)
);

select * from acma_specialty
