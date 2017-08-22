
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
