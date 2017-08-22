create or replace procedure acma_patient_add(
-- comment
fullname in varchar2,
nic in varchar2,
telephone in number,
address in varchar2
)
as begin
   insert into acma_patient (fullname, nic, telephone,address) values(fullname, nic,telephone,address);
end;

declare 
  fname varchar2(255) := 'Delushaa deku';
  nic varchar2 (15):= '990828845v';
  tele number := 0715404579;
  addr varchar(255) := 'Colombo main stree, Sri Lanka';
begin
  acma_patient_add(fname, nic, tele, addr);
  dbms_output.put_line('Inserted');
end;

CREATE SEQUENCE auto_num
  START WITH 'patn_'1
  INCREMENT BY 1
  CACHE 10000;
  
  CREATE OR REPLACE TRIGGER acma_patient_add_trig
  BEFORE INSERT ON acma_patient
  FOR EACH ROW
BEGIN
  SELECT auto_num.nextval
    INTO :new.patient_id
    FROM dual;
END;


select * from acma_patient
delete from acma_patient where patient_id = 5
