--create type object for store table of records
create or replace type acma_app_o as object
(app_id number, pat_id varchar2(64), doc_id varchar2(64), cre date, app_d date, app_t varchar2(64), cat varchar2(64), sta number);

--store object to table
create or replace type acma_app_t is table of acma_app_o;

--function to view appointment details
create or replace function acma_cancel_appoinment_view(app_id number) 
return acma_app_t
as data_set acma_app_t;
begin
  select acma_app_o(ap.appoinment_id, p.fullname, d.fullname, ap.created_date_time, ap.appointment_date,ap.appointment_time, ap.consulting_catogery, ap.status) 
  bulk collect into data_set 
  from acma_appoinment ap
  left join acma_patient p on ap.patient_id = p.patient_id
  left join acma_doctor d on ap.doctor_id = d.doctor_id
  where ap. appoinment_id= app_id and ap.status = 1 order by ap.appoinment_id;
  return data_set;
  
end;

--client side view and get multiple data
declare
  datas acma_app_t;
begin
  datas := acma_cancel_appoinment_view(15);
  for x in 1..datas.count loop
    dbms_output.put_line(
    'Appointment_id : '||datas(x).app_id || 
    ' Patient_id : ' ||datas(x).pat_id ||
    ' Doctor_id : ' ||datas(x).doc_id ||
    ' Created Date Time : ' ||datas(x).cre||
    ' Appointment Date Time : ' ||datas(x).app_d||
    ' Appointment Date Time : ' ||datas(x).app_t||
    ' Catogery : ' ||datas(x).cat||
    ' Status : ' ||datas(x).sta 
    );
  end loop;
end;


--procedure for update status to cancel appoinment
create or replace procedure acma_cancel_appoinment(app_id number)
as
 myexp exception;
begin
  update acma_appoinment set status = 0 where appoinment_id = app_id;
	commit;
-- excepetion is not working "I dont know why"
  exception when no_data_found then
      dbms_output.put_line('No Appoinment Found!');
end;

-- client side checking the procedure to cancel the apponment
declare
   appoint_id number := &appoinment_id;
begin
  acma_cancel_appoinment(appoint_id);
  end;



select * from acma_appoinment

















select * from acma_appoinment
