# PAPractica3 Constitucion

## Principios Base

### I. Modelo OO estricto

El dominio se modela con herencia, abstraccion y encapsulamiento: `Persona` como base, `Medico` abstracto y derivados concretos `MedicoGeneral` y `MedicoEspecialista`. No se permiten atajos con estructuras paralelas ni duplicacion de logica de sueldo.

### II. Reglas de negocio verificables

Todas las reglas de sueldo, bonos y descuentos se implementan como metodos claros (`CalcularSueldo`, `CalcularBono`, `MostrarTipoMedico`) con entradas deterministas y sin efectos colaterales.

### III. LINQ to Objects como fuente de consultas

Las consultas de listados, filtros y agrupaciones se realizan con LINQ to Objects sobre colecciones en memoria; no se usa SQL ni acceso a datos externo.

### IV. Claridad en calculos monetarios

Los calculos monetarios deben ser consistentes y legibles; se prioriza la exactitud con tipos adecuados y constantes descriptivas para porcentajes y bonos.

### V. IU como presentacion, no logica

La logica de negocio permanece en clases de dominio y listas; los formularios solo orquestan y muestran resultados.

## Alcance Funcional

- Clase `Persona` con `IdCodigo`, `Cedula`, `Nombre`, `Apellido`, `FechaNacimiento`, `Estado`.
- Clase abstracta `Medico` con `Especialidad`, `NumeroConsultorio`, `AniosExperiencia`, `SueldoBase` y metodos abstractos.
- `MedicoGeneral` con sueldo mensual, descuento IESS 9.32 %, bono por consulta, bonificacion por superar 80 consultas.
- `MedicoEspecialista` con sueldo mensual, comision por cirugia, descuento IESS 9.32 %, bono por cirugia exitosa, bonificacion por experiencia.
- Bonificacion por cumpleanos segun edad en el mes de pago.
- Gestion de lista: insertar, eliminar, listar y filtrar por tipo.

## Flujo de Desarrollo

- Modelar UML interno en Visual Studio antes de codificar.
- Implementar clases de dominio primero, luego lista de gestion y finalmente formularios.
- Cada regla de negocio debe quedar cubierta por al menos un caso de prueba manual documentado en el comentario del commit o notas de desarrollo.

## Gobernanza

- Esta constitucion prevalece sobre convenciones informales del equipo.
- Cambios a reglas de negocio requieren actualizar esta constitucion y los metodos afectados.

**Version**: 1.0.0 | **Ratificado**: 2026-06-02 | **Ultima Modificacion**: 2026-06-02
