DROP TABLE ACMA_DUTY

CREATE TABLE ACMA_DUTY (
       DUTY_ID NUMBER NOT NULL PRIMARY KEY,
       DOCTOR_ID NUMBER NOT NULL REFERENCES ACMA_DOCTOR(DOCTOR_ID) ON DELETE CASCADE,
       CONSULTING_DATE NUMBER,
       CONSULTING_TIME_BEGIN VARCHAR(15),
       CONSULTING_TIME_END VARCHAR(15),
       LOCK_STATUS NUMBER(1,0) DEFAULT 0,
       TICKETS_PER_DAY NUMBER,
       REMAINING_TICKET NUMBER,
       CONSTRAINT UNI_CON UNIQUE (DOCTOR_ID,CONSULTING_DATE) 
)
