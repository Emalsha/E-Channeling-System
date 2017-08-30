--procedure starts
create or replace procedure acma_doctor_update_dutyinfo(
<<<<<<< HEAD
doctor_id_ in number,
=======
doctor_id in number,
>>>>>>> master
available_on_weekend_ in number,
patient_per_day_ in number,
time_per_patient_ in number)
as
begin
<<<<<<< HEAD
  update acma_doctor set available_on_weekend = available_on_weekend_, patient_per_day = patient_per_day_, time_per_patient = time_per_patient_ where doctor_id = doctor_id_;
=======
  update acma_doctor set available_on_weekend = available_on_weekend_, patient_per_day = patient_per_day_, time_per_patient = time_per_patient_ where doctor_id = doctor_id;
  commit;
>>>>>>> master
end;
  
--client side check procedure with data  
declare
  do_id number := &doctor_id;
  weekend number := 1;
  patient_no number := 20;
  patient_time number := 30;
begin
  acma_doctor_update_dutyinfo(do_id,weekend,patient_no,patient_time);
end;

select * from acma_doctor
