--create function for search patient by nic
create or replace function acma_patient_search_by_nic(nic_no varchar2)
return varchar2
is
temp varchar2(64);
myexp exception;
notf varchar2(64) := 'no_user_found';
begin
  select fullname into temp from acma_patient where nic = nic_no;
  return temp;
     exception when others then 
    if sqlcode = +100 then
      --dbms_output.put_line('No row of data found');
      return notf;
    else
      raise;
      return notf;
    end if;
end;

--client side search method with data of patient nic number
declare
  nic varchar2(15);
begin
  nic := acma_patient_search_by_nic('960290583dV');
  dbms_output.put_line(nic);
end;

select * from acma_patient

