SELECT QDCDB_REG_CD('Z67','2.16.840.1.113883.6.90','Blood Type',NULL);
SELECT QDCDB_REG_CD('Z67.1','2.16.840.1.113883.6.90','Blood type,  Type A blood',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67'));
SELECT QDCDB_REG_CD('Z67.10','2.16.840.1.113883.6.90','Blood type,  Type A blood,  Rh positive',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.1'));
SELECT QDCDB_REG_CD('Z67.11','2.16.840.1.113883.6.90','Blood type,  Type A blood,  Rh Negative',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.1'));
SELECT QDCDB_REG_CD('Z67.2','2.16.840.1.113883.6.90','Blood type,  Type B blood',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67'));
SELECT QDCDB_REG_CD('Z67.20','2.16.840.1.113883.6.90','Blood type,  Type B blood,  Rh positive',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.2'));
SELECT QDCDB_REG_CD('Z67.21','2.16.840.1.113883.6.90','Blood type,  Type B blood,  Rh negative',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.2'));
SELECT QDCDB_REG_CD('Z67.3','2.16.840.1.113883.6.90','Blood type,  Type AB blood',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67'));
SELECT QDCDB_REG_CD('Z67.30','2.16.840.1.113883.6.90','Blood type,  Type AB blood,  Rh positive',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.3'));
SELECT QDCDB_REG_CD('Z67.31','2.16.840.1.113883.6.90','Blood type,  Type AB blood,  Rh negative',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.3'));
SELECT QDCDB_REG_CD('Z67.4','2.16.840.1.113883.6.90','Blood type,  Type O blood',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67'));
SELECT QDCDB_REG_CD('Z67.40','2.16.840.1.113883.6.90','Blood type,  Type O blood,  Rh positive',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.4'));
SELECT QDCDB_REG_CD('Z67.41','2.16.840.1.113883.6.90','Blood type,  Type O blood,  Rh negative',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.4'));
SELECT QDCDB_REG_CD('Z67.9','2.16.840.1.113883.6.90','Blood type,  Unspecified blood type',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67'));
SELECT QDCDB_REG_CD('Z67.90','2.16.840.1.113883.6.90','Blood type,  Unspecified blood type,  Rh positive',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.9'));
SELECT QDCDB_REG_CD('Z67.91','2.16.840.1.113883.6.90','Blood type,  Unspecified blood type,  Rh negative',QDCDB_GET_CD('2.16.840.1.113883.6.90','Z67.9'));
