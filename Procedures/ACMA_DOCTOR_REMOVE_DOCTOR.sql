--procedures starts
create or replace procedure acma_doctor_remove_doctor(
doctor_id in number
)
as
begin
  delete from acma_doctor where doctor_id = doctor_id;
end;

--client side check procedure
declare
 doctor_id number := &doca_id;
begin
  acma_doctor_remove_doctor(doctor_id);
end;

