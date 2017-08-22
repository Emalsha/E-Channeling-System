-------------------------------------------- Sequence 
CREATE SEQUENCE ACMA_DOCTOR_ID
MINVALUE 1
START WITH 8
INCREMENT BY 1
CACHE 20;

-------------------------------------------- Procedure

CREATE OR REPLACE PROCEDURE ACMA_DOCTOR_ADD(
       FULLNAME_ IN VARCHAR2,
       TELEPHONE_ IN NUMBER,
       ADDRESS_ IN VARCHAR2,
       NIC_ IN VARCHAR2,
       AVAILABLE_ON_WEEKEND_ IN NUMBER,
       PATIENT_PER_DAY_ IN NUMBER,
       TIME_PER_PATIENT_ IN NUMBER,
       ROOM_NUMBER_ IN VARCHAR2,
       USERNAME_ IN VARCHAR,
       PASSWORD_ IN VARCHAR,
       EMAIL_ IN VARCHAR2
)
IS
BEGIN
  INSERT INTO ACMA_DOCTOR
  VALUES(
       ACMA_DOCTOR_ID.NEXTVAL,
       FULLNAME_,
       TELEPHONE_,
       ADDRESS_,
       NIC_,
       AVAILABLE_ON_WEEKEND_ ,
       PATIENT_PER_DAY_ ,
       TIME_PER_PATIENT_,
       ROOM_NUMBER_ ,
       USERNAME_ ,
       PASSWORD_,
       EMAIL_
  );
  COMMIT;
END;

DECLARE
BEGIN
  ACMA_DOCTOR_ADD('Dr.Prasanna Serasinghe',0710868178,'AB923,Haputhale Road,Bandarawela','89055145v',0,10,10,6,'prasanna','123','prasanna@gmail.com');
END;
  
