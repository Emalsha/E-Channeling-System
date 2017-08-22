create or replace function acma_patient_search_by_nic(nic_no varchar2)
return varchar2
is
temp varchar2(64);
myexp exception;
begin
  select fullname into temp from acma_patient where nic = nic_no;
  return temp;
     exception when others then 
    if sqlcode = +100 then
      dbms_output.put_line('No row of data found');
      return null;
    else
      raise;
      return null;
    end if;
end;


declare
  nic varchar2(15);
begin
  nic := acma_patient_search_by_nic('960290583V');
  dbms_output.put_line(nic);
end;

