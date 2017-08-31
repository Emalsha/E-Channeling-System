drop type ACMA_DOCTOR_DATE_RESULT_TBL
-- TYPE
CREATE OR REPLACE TYPE ACMA_DOCTOR_DATE_RESULT_OBJ AS OBJECT(
       DOCTOR_ID NUMBER,
       FULLNAME VARCHAR2(255),
       AVAILABLE_ON_WEEKEND NUMBER,
       ROOM_NUMBER NUMBER,
       DESCRIPTION VARCHAR(512)
)

CREATE OR REPLACE TYPE ACMA_DOCTOR_DATE_RESULT_TBL AS TABLE OF ACMA_DOCTOR_DATE_RESULT_OBJ
--

CREATE OR REPLACE FUNCTION ACMA_DOCTOR_SEARCH_BY_SPECDATE(
       SEPC_ IN VARCHAR2,
       DATE_ IN NUMBER
)
RETURN ACMA_DOCTOR_DATE_RESULT_TBL
AS RES_TBL ACMA_DOCTOR_DATE_RESULT_TBL;
BEGIN
  SELECT ACMA_DOCTOR_DATE_RESULT_OBJ(D.DOCTOR_ID,D.FULLNAME,D.AVAILABLE_ON_WEEKEND,D.ROOM_NUMBER,S.DESCRIPTION)
  BULK COLLECT INTO RES_TBL
  FROM ACMA_DOCTOR D
  LEFT JOIN ACMA_DOCTOR_SPECIALTY DS ON D.DOCTOR_ID = DS.DOCTOR_ID
  LEFT JOIN ACMA_SPECIALTY S ON DS.SPECIALTY_ID = S.SPECIALTY_ID
  LEFT JOIN ACMA_DUTY AD ON D.DOCTOR_ID = AD.DOCTOR_ID
  WHERE lower(S.DESCRIPTION) LIKE lower('%'||SEPC_||'%')AND CONSULTING_DATE = DATE_
  ORDER BY D.FULLNAME;
  
  RETURN RES_TBL;
END;
 
DECLARE 
    RES_LIST ACMA_DOCTOR_DATE_RESULT_TBL;
BEGIN
  RES_LIST := ACMA_DOCTOR_SEARCH_BY_SPECDATE('Al',0);
  FOR X IN 1..RES_LIST.COUNT 
    LOOP
      DBMS_OUTPUT.PUT_LINE('DATA :' || RES_LIST(X).DOCTOR_ID || '  ' || RES_LIST(X).FULLNAME || '  ' || RES_LIST(X).AVAILABLE_ON_WEEKEND || '  ' || RES_LIST(X).ROOM_NUMBER || '  ' || RES_LIST(X).DESCRIPTION );
  END LOOP;
END;

SELECT * FROM ACMA_DOCTOR_SPECIALTY
SELECT * FROM ACMA_SPECIALTY
select * from acma_doctor
select * from acma_duty






------------------------------------ SQL
SELECT D.DOCTOR_ID,D.FULLNAME,D.AVAILABLE_ON_WEEKEND,D.ROOM_NUMBER,S.DESCRIPTION,AD.CONSULTING_DATE,AD.CONSULTING_TIME_BEGIN,AD.CONSULTING_TIME_END
  FROM ACMA_DOCTOR D
  LEFT JOIN ACMA_DOCTOR_SPECIALTY DS ON D.DOCTOR_ID = DS.DOCTOR_ID
  LEFT JOIN ACMA_SPECIALTY S ON DS.SPECIALTY_ID = S.SPECIALTY_ID
  LEFT JOIN ACMA_DUTY AD ON D.DOCTOR_ID = AD.DOCTOR_ID
  WHERE lower(S.DESCRIPTION) LIKE lower('%Allergist%') AND to_char(AD.CONSULTING_DATE, 'MM/DD/yyyy') = '08/24/2017'
  ORDER BY D.FULLNAME 

-------------------------------
select * from acma_patient
