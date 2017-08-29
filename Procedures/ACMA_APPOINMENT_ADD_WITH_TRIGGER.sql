-- CREARE PROCEDURE FOR ADD APPOINMENT TO THE DATABASE
create or replace procedure acma_appoinment_add(
pa_id in number,
do_id in number,
ap_date in date,
ap_time in varchar2,
cat in varchar2
)
as 
begin
  insert into acma_appoinment (patient_id, doctor_id,created_date_time,appointment_date,appointment_time,consulting_catogery,status)
  values (pa_id, do_id, sysdate, ap_date,ap_time, cat, 1);
  commit;
end;

-- CLIENT SIDE TESTING WITH DATA ROW
declare
pat_id number := 3;
doc_id number := 5;
ap_date date :=to_date('8/24/2017','MM/DD/yyyy');
ap_time varchar2(64) := '08.30.24 PM';
cat varchar2(65) := 'Eye Ear Thoiraid';

begin
  acma_appoinment_add(pat_id,doc_id,ap_date,ap_time,cat);
end;


-- create seqence for auto number for appoinment 
CREATE SEQUENCE auto_num_appoinment
  START WITH 1
  INCREMENT BY 1
  CACHE 10000;
  
-- create a triggr auto number primary id when a new patient regester to the system  
  CREATE OR REPLACE TRIGGER acma_appoinment_add_trig
  BEFORE INSERT ON acma_appoinment
  FOR EACH ROW
BEGIN
  SELECT auto_num.nextval
    INTO :new.appoinment_id
    FROM dual;
end;

select * from acma_appoinment
