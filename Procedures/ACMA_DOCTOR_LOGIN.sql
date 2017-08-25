-- login auth checking function by username and password 
create or replace function acma_doctor_login(username_ in varchar2, password_ in varchar2)
return number
as
  match_count number;
  doctor_id_ number;
begin
  select count(*) into match_count from acma_doctor where username=username_ and password=password_;
  dbms_output.put_line(match_count);
  if match_count = 0 then
    -- No user;
    return 0;
  elsif match_count = 1 then
    select doctor_id into doctor_id_ from acma_doctor where username=username_ and password=password_;
    -- Return doctor id
    return doctor_id_;
  else
    -- Too many result
    return -1;
  end if;
end;
/

-- clinet side data chk auth function 
declare
usename varchar2(64) := 'sadun';
password varchar2(64) := '123';
output number;
begin
  output := acma_doctor_login(usename,password);
   dbms_output.put_line(output);
end; 

