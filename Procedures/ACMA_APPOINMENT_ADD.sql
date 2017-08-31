-- CREARE PROCEDURE FOR ADD APPOINMENT TO THE DATABASE
create or replace procedure acma_appoinment_add(
patient_id in number,
doctor_id in number,
appoinment_date in NUMBER,
appoinment_time in varchar2,
category_ in varchar2
)
as
appoinment_day DATE;
day_name VARCHAR2(50);
begin
  
  CASE appoinment_date
    WHEN 1 THEN day_name :='SUNDAY';
      WHEN 2 THEN  day_name :='MONDAY';
        WHEN 3 THEN day_name :='TUESDAY';
          WHEN 4 THEN day_name :='WEDNESDAY';
            WHEN 5 THEN day_name :='THURSDAY';
              WHEN 6 THEN day_name :='FRIDAY';
                WHEN 7 THEN day_name :='SATURDAY';
                  END CASE;
  

  IF ( appoinment_date = to_char(sysdate,'D') ) THEN
    appoinment_day :=  TO_DATE(to_char(sysdate,'mm/dd/yyyy'),'MM/DD/YYYY');
  ELSE
    appoinment_day := TO_DATE(to_char(next_day(sysdate,day_name),'MM/DD/YYYY'),'MM/DD/YYYY');
  END IF;
  
  insert into acma_appoinment
  values (appoinment_id_seq.NEXTVAL,patient_id, doctor_id, sysdate, appoinment_day,appoinment_time, category_, 1);
  commit;
end;

-- CLIENT SIDE TESTING WITH DATA ROW
declare
pat_id number := 5;
doc_id number := 6;
ap_date NUMBER :=7;
ap_time varchar2(64) := '08.30.24 PM';
cat varchar2(65) := 'Eye Ear Thoiraid';

begin
  acma_appoinment_add(pat_id,doc_id,ap_date,ap_time,cat);
end;

--------------- SAMPLE
BEGIN
  IF(4 = to_char(sysdate,'D')) THEN
     DBMS_OUTPUT.PUT_LINE('SOKO');
  END IF;
END;



-- create seqence for auto number for appoinment 
DROP SEQUENCE auto_num_appoinment
CREATE SEQUENCE appoinment_id_seq
  MINVALUE 1
  START WITH 32
  INCREMENT BY 1
  CACHE 3;
 

select * from acma_appoinment



select * from acma_patient
select patient_id from acma_patient where nic = 'as'
