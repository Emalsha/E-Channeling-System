create or replace procedure acma_doctor_update_accountinfo(
doctor_id_ in number,
username_ in varchar2,
password_ in varchar2,
email_ in varchar2)
as
begin
  update acma_doctor set username = username_, password = password_, email = email_ where doctor_id = doctor_id_;
  commit;
end;
  
  
declare
  do_id number := &doctor_id;
  username varchar2(64) := 'delushaadelu';
  password varchar2(64) := '077114143d';
  email varchar2(64) := 'delushaan@gmail.com';
begin
  acma_doctor_update_accountinfo(do_id,username,password,email);
end;

select * from acma_doctor
