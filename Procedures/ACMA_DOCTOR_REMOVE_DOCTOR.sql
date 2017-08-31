--procedures starts
CREATE OR REPLACE PROCEDURE acma_doctor_remove_doctor(
doctor_id_ in NUMBER,
output out varchar2
)
AS 
BEGIN
  DELETE FROM acma_doctor_specialty d WHERE d.doctor_id = doctor_id_;
  DELETE FROM acma_duty WHERE acma_duty.doctor_id = doctor_id_;
  DELETE FROM ACMA_APPOINMENT WHERE ACMA_APPOINMENT.doctor_id = doctor_id_;
  DELETE FROM acma_doctor WHERE acma_doctor.doctor_id = doctor_id_;
      IF(SQL%ROWCOUNT > 0)
      THEN OUTPUT := 'Doctor removed.';commit;
      ELSE OUTPUT := 'Remove Failed.';
      END IF;  
END;

--client side check procedure
declare
 doctor_id number := 4;
 str varchar2(100);
begin
  acma_doctor_remove_doctor(doctor_id,str);
  DBMS_OUTPUT.PUT_LINE(STR);
end;

