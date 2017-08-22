CREATE TABLE ACMA_DOCTOR_SPECIALTY (
    doctor_specialty_id number not null,
    doctor_id  references ACMA_DOCTOR(doctor_id),
    specialty_id  references ACMA_SPECIALTY(specialty_id),
    primary key (specialty_id)
);
