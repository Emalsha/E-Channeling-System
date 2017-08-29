--procedure starts
create or replace procedure acma_doctor_update_basicinfo(
doctor_id_ in number,
fullname_ in varchar2,
telephone_ in number,
address_ in varchar2,
nic_no in varchar2, 
room_number_ in number)
as
begin
  update acma_doctor set fullname = fullname_, telephone = telephone_, address = address_, nic = nic_no, room_number = room_number_ where doctor_id = doctor_id_;
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
  dbms_output.put_line('done');
end;

select * from acma_doctor
