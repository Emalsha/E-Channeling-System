create or replace procedure acma_doctor_update_accountinfo(
doc_id in number,
usern in varchar2,
pass in varchar2,
mail in varchar2)
as
begin
  update acma_doctor set username = usern, password = pass, email = mail where doctor_id = doc_id;
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
