create or replace procedure acma_doctor_update_dutyinfo(
doc_id in number,
weekend in number,
patient_no in number,
patient_time in number)
as
begin
  update acma_doctor set available_on_weekend = weekend, patient_per_day = patient_no, time_per_patient = patient_time where doctor_id = doc_id;
end;
  
  
declare
  do_id number := &doctor_id;
  weekend number := 1;
  patient_no number := 20;
  patient_time number := 30;
begin
  acma_doctor_update_dutyinfo(do_id,weekend,patient_no,patient_time);
end;

select * from acma_doctor
