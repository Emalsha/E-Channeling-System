--create a procedre to add new receptionist
create or replace procedure acma_reception_add(
  recpt_name in varchar2,
  recpt_email in varchar2,
  recpt_tele in number, 
  recpt_user in varchar2,
  recpt_pass in varchar2
)
as
begin 
  insert into acma_reception (receptionist_name,receptionist_email,telephone,username,r_password)
  values (recpt_name, recpt_email, recpt_tele, recpt_user, recpt_pass);
end;

--client side data inserting to the trigger
declare
  recp_name varchar2(64) := 'Delushaan Delu';
  recp_email varchar2(32) := 'delushaandelu@gmail.com';
  recp_tele number := 0715404579;
  recp_user varchar2(32) := 'delushaan';
  reco_pass varchar2(64) := 'delushaan123';
begin
  acma_reception_add(recp_name,recp_email,recp_tele,recp_user,reco_pass);
end;

-- create a swquance to add auto number to reception
CREATE SEQUENCE acma_reception_add_sq
  START WITH 2
  INCREMENT BY 1
  CACHE 10000;
  
-- auto number tirger\
CREATE OR REPLACE TRIGGER acma_reception_add_trg
  BEFORE INSERT ON acma_reception
  FOR EACH ROW
BEGIN
  SELECT auto_num.nextval
    INTO :new.receptionist_id
    FROM dual;
end;

select * from acma_reception

