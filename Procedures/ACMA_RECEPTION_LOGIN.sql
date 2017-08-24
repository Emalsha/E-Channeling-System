-- login auth checking function by username and password 
create or replace function acma_reception_login(user in varchar2, pass in varchar2)
return varchar2
as
  match_count number;
  log_id varchar2(64);
begin
  select count(*) into match_count from acma_reception where username=user and r_password=pass;
  if match_count = 0 then
    return 'Wrong username or password!';
  elsif match_count = 1 then
    select receptionist_name into log_id from acma_reception where username=user and r_password=pass;
    -- returning the fullname of the user to chk the auth success conformation
    return log_id;
  else
    return 'Too many matches, this should never happen!';
  end if;
end;
/

-- clinet side data chk auth function 
declare
usename varchar2(64) := 'delushaan';
password varchar2(64) := 'delushaan123';
output varchar2(128);
begin
  output := acma_reception_login(usename,password);
   dbms_output.put_line(output);
end; 

select * from acma_reception