create or replace procedure acma_patient_add(
patient_id in number,
fullname in varchar2,
nic in varchar2,
telephone in number,
address in varchar2
)
as begin
   insert into acma_patient values(patient_id, fullname, nic,telephone,address);
end;

declare 
  p_id number := 4;
  fname varchar2(255) := 'jilla';
  nic varchar2 (15):= '930828847v';
  tele number := 0715404579;
  addr varchar(255) := 'hatton town, Sri Lanka';
begin
  acma_patient_add(p_id, fname, nic, tele, addr);
  dbms_output.put_line('Inserted');
  
end;

select * from acma_patient;

delete from acma_patient where patient_id = 6
