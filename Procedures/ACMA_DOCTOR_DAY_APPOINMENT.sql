DROP TYPE ACMA_DOC_DAY_TBL

--OBJ
CREATE OR REPLACE TYPE ACMA_DOC_DAY_OBJ AS OBJECT
(appinment_id NUMBER, patient_id NUMBER ,patient_name varchar2(64), appoinment_created_date date,appoinment_time varchar2(64), catogery varchar2(64), sta number);

--TBL
CREATE OR REPLACE TYPE ACMA_DOC_DAY_TBL IS TABLE OF ACMA_DOC_DAY_OBJ;

--Function
CREATE OR REPLACE FUNCTION ACMA_DOCTOR_DAY_APPOINMENT(day_number VARCHAR2,doctor_id_ NUMBER) 
RETURN ACMA_DOC_DAY_TBL
AS RES_TBL ACMA_DOC_DAY_TBL;
   appoinment_day VARCHAR2(50);
   day_name VARCHAR2(50);
BEGIN
   
   CASE day_number
    WHEN 1 THEN day_name :='SUNDAY';
      WHEN 2 THEN  day_name :='MONDAY';
        WHEN 3 THEN day_name :='TUESDAY';
          WHEN 4 THEN day_name :='WEDNESDAY';
            WHEN 5 THEN day_name :='THURSDAY';
              WHEN 6 THEN day_name :='FRIDAY';
                WHEN 7 THEN day_name :='SATURDAY';
                  END CASE;
  

  IF ( day_number = to_char(sysdate,'D') ) THEN
    appoinment_day :=  to_char(sysdate,'mm/dd/yyyy');
  ELSE
    appoinment_day := to_char(next_day(sysdate,day_name),'MM/DD/YYYY');
  END IF;  


  SELECT ACMA_DOC_DAY_OBJ(ap.appoinment_id, ap.patient_id, p.fullname, ap.created_date_time, ap.appointment_time, ap.consulting_catogery, ap.status) 
  BULK COLLECT INTO RES_TBL 
  FROM acma_appoinment ap
  LEFT JOIN acma_patient p on ap.patient_id = p.patient_id
  WHERE to_char(ap.appointment_date, 'mm/dd/yyyy') = appoinment_day AND AP.DOCTOR_ID = DOCTOR_ID_ order by ap.appoinment_id;
  RETURN RES_TBL;
END;

--SQL
SELECT ACMA_DOC_DAY_OBJ(ap.appoinment_id, ap.patient_id, p.fullname, ap.created_date_time, ap.appointment_time, ap.consulting_catogery, ap.status) 
  FROM acma_appoinment ap
  LEFT JOIN acma_patient p on ap.patient_id = p.patient_id
  WHERE to_char(ap.appointment_date, 'mm/dd/yyyy') = '8/23/2017' AND AP.DOCTOR_ID = 5 order by ap.appoinment_id;

SELECT to_char(appointment_date, 'mm/dd/yyyy') FROM acma_appoinment

-- Testing
declare
  datas ACMA_DOC_DAY_TBL;
begin
  datas := ACMA_DOCTOR_DAY_APPOINMENT(7,41);
  for x in 1..datas.count loop
    dbms_output.put_line(
    'Appointment_id : '||datas(x).appinment_id || 
    ' Patient_id : ' ||datas(x).patient_id ||
    ' Patient : ' ||datas(x).patient_name ||
    ' Created Date Time : ' ||datas(x).appoinment_created_date||
    ' Appointment Time : ' ||datas(x).appoinment_time||
    ' Catogery : ' ||datas(x).catogery||
    ' Status : ' ||datas(x).sta 
    );
  end loop;
end;

select * from table( acma_doctor_day_appoinment('5',41) )
