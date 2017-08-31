--create procedure commad
create or replace function acma_patient_delete_by_nic(nic_no varchar2)
return number
is
myexp exception;
begin
  delete from acma_patient where nic = nic_no;
  return 1;
     exception when others then 
    if sqlcode = +100 then
      dbms_output.put_line('No row of data found');
      return null;
    else
      raise;
      return null;
    end if;
end;


--slient site check the procedure with data
declare
  nic varchar2(15);
begin
  nic := acma_patient_delete_by_nic('9636cbcvbvcbcv93V');
  dbms_output.put_line(nic);
end;

select * from acma_patient

select * from acma_doctor
