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
       EMAIL_ IN VARCHAR2,
       DOCTOR_SPECILATY IN VARCHAR2,
       OUTPUT OUT VARCHAR2
)
IS
  DOCTOR_ID NUMBER := ACMA_DOCTOR_ID.NEXTVAL;
BEGIN
  INSERT INTO ACMA_DOCTOR
  VALUES(
       DOCTOR_ID,
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
  IF(SQL%ROWCOUNT > 0)
  THEN 
    OUTPUT := 'New Doctor details added.';
    ACMA_SPECIALTY_ADD(DOCTOR_ID,DOCTOR_SPECILATY);
  ELSE OUTPUT := 'Failed.';
  END IF;
  COMMIT;
END;

DECLARE
 output varchar2(100);
BEGIN
  ACMA_DOCTOR_ADD('Dr.Prasanna Serasinghe',0710868178,'AB923,Haputhale Road,Bandarawela','89055145v',0,10,10,8,'prasanna','123','prasanna@gmail.com','Plastic surgeon',OUTPUT);
END;
  

























