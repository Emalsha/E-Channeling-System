--procedure starts
create or replace procedure acma_doctor_update_basicinfo(
doc_id in number,
fname in varchar2,
phone in number,
addr in varchar2,
nic_no in varchar2, 
room in number)
as
begin
  update acma_doctor set fullname = fname, telephone = phone, address = addr, nic = nic_no, room_number = room where doctor_id = doc_id;
  commit;
end;
  
--client side check procedure with data
declare
  do_id number := &doctor_id;
  fname varchar2(64) := 'Dr.Jill delushaan delu don';
  phone number := 0715404579;
  address varchar2(255) := 'No 110, colombo Rosita Houising scheme, kotagala';
  nic varchar(15) := '990280580V';
  room number := 60;
begin
  acma_doctor_update_basicinfo(do_id,fname,phone,address,nic,room);
end;

select * from acma_doctor
