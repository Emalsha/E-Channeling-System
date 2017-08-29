-- CREARE PROCEDURE FOR ADD APPOINMENT TO THE DATABASE
create or replace procedure acma_appoinment_add(
patient_id in number,
doctor_id in number,
appoinment_date in date,
appoinment_time in varchar2,
category_ in varchar2
)
as 
begin
  insert into acma_appoinment
  values (appoinment_id_seq.NEXTVAL,patient_id, doctor_id, sysdate, appoinment_date,appoinment_time, category_, 1);
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
DROP SEQUENCE auto_num_appoinment
CREATE SEQUENCE appoinment_id_seq
  MINVALUE 1
  START WITH 32
  INCREMENT BY 1
  CACHE 3;
 

select * from acma_appoinment
