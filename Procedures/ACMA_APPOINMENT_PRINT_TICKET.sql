--create type object for store table of records
create or replace type acma_app_o as object
(app_id number, pat_id varchar2(64), doc_id varchar2(64), cre date, app_d date, cat varchar2(64), sta number);

--store object to table
create or replace type acma_app_t is table of acma_app_o;

--function to view appointment details
create or replace function acma_appoinment_print_ticket(app_id number) 
return acma_app_t
as data_set acma_app_t;
begin
  select acma_app_o(ap.appoinment_id, p.fullname, d.fullname, ap.created_date_time, ap.appointment_date_time, ap.consulting_catogery, ap.status) 
  bulk collect into data_set 
  from acma_appoinment ap
  left join acma_patient p on ap.patient_id = p.patient_id
  left join acma_doctor d on ap.doctor_id = d.doctor_id
  where ap. appoinment_id= app_id order by ap.appoinment_id;
  return data_set;
end;

--client side view and get multiple data
declare
  datas acma_app_t;
begin
  datas := acma_appoinment_print_ticket(8);
  for x in 1..datas.count loop
    dbms_output.put_line('Appointment_id : '||datas(x).app_id);
    dbms_output.put_line(' Patient_Name : ' ||datas(x).pat_id);
    dbms_output.put_line(' Doctor_Name : ' ||datas(x).doc_id );
    dbms_output.put_line(' Created Date Time : ' ||datas(x).cre);
    dbms_output.put_line(' Appointment Date Time : ' ||datas(x).app_d);
    dbms_output.put_line(' Catogery : ' ||datas(x).cat);
    
    if (datas(x).sta = 1)then
      dbms_output.put_line(' Status : Appointment Active');
    else
      dbms_output.put_line(' Status : Appointment Canceld');
    end if;
  end loop;
end;
