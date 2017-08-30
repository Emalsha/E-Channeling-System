-------------------------------------------- Sequence 
CREATE SEQUENCE ACMA_SPECIALTY_ID
MINVALUE 1
START WITH 10
INCREMENT BY 1
CACHE 20;


-------------------------------------------- Procedure

CREATE OR REPLACE PROCEDURE ACMA_SPECIALTY_ADD(
       DOCTOR_ID_ IN NUMBER,
       SPECIALTY_NAME_ IN VARCHAR2
)
IS
BEGIN
  INSERT INTO ACMA_DOCTOR_SPECIALTY
  VALUES(
       ACMA_SPECIALTY_ID.NEXTVAL,
       DOCTOR_ID_,
       (SELECT SPECIALTY_ID FROM ACMA_SPECIALTY WHERE DESCRIPTION=SPECIALTY_NAME_ )
  );
  COMMIT;
END;


----------------------------
DECLARE
BEGIN
  ACMA_SPECIALTY_ADD(28,'Radiation oncologist');
END;