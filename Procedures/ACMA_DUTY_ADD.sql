-------------------------------------------- Sequence 
CREATE SEQUENCE ACMA_DUTY_ID
MINVALUE 1
START WITH 1
INCREMENT BY 1
CACHE 20;


-------------------------------------------- Procedure

CREATE OR REPLACE PROCEDURE ACMA_DUTY_ADD(
       DOCTOR_ID_ IN NUMBER,
       CONSULTING_DATE_ IN NUMBER,
       CONSULTING_TIME_BEGIN_ IN VARCHAR2,
       CONSULTING_TIME_END_ IN VARCHAR2,
       LOCK_STATUS_ IN NUMBER,
       TICKETS_PER_DAY_ IN NUMBER,
       REMAINING_TICKET_ IN NUMBER,
       OUTPUT OUT VARCHAR2
)
IS
BEGIN
  INSERT INTO ACMA_DUTY
  VALUES(
       ACMA_DUTY_ID.NEXTVAL,
       DOCTOR_ID_,
       CONSULTING_DATE_,
       CONSULTING_TIME_BEGIN_,
       CONSULTING_TIME_END_,
       LOCK_STATUS_,
       TICKETS_PER_DAY_,
       REMAINING_TICKET_
  );
  IF(SQL%ROWCOUNT > 0)
  THEN OUTPUT := 'New time slot added.';
  ELSE OUTPUT := 'Not inserted.';
  END IF;
  COMMIT;
EXCEPTION
  WHEN OTHERS THEN 
    IF SQLCODE = -0001 THEN
      OUTPUT := 'Alread have. Please update.';
    END IF;
END;

--------------------------------

DECLARE
  res varchar2(100);
BEGIN
  ACMA_DUTY_ADD(06,2,'12:00:00','15:00:00',0,6,4,res);
  dbms_output.put_line(res);
END;
  
begin 
  dbms_output.put_line(TO_CHAR(sysdate,'D'));
  end;
