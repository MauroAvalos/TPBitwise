﻿ALTER TABLE TuTabla
DROP CONSTRAINT PK_TareaEtiquetas;
ALTER TABLE TuTabla
DROP COLUMN Id;
ALTER TABLE TuTabla
ADD NuevaColumna INT;
ALTER TABLE TuTabla
ADD CONSTRAINT PK_TareaEtiquetas PRIMARY KEY (NuevaColumna);