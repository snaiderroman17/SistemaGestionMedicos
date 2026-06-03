using System;
using System.Collections.Generic;
using PAPractica3.Entidades;
using PAPractica3.Lista;

namespace PAPractica3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE MÉDICOS ===\n");

            // Crear instancia de la lista de médicos
            ListaMedicos gestorMedicos = new ListaMedicos();

            // Crear y insertar médicos de prueba
            Console.WriteLine("📋 Cargando médicos de prueba...\n");

            // Médico General 1
            MedicoGeneral mg1 = new MedicoGeneral(
                idCodigo: "MG001",
                cedula: "0123456789",
                nombre: "Carlos",
                apellido: "Martínez",
                fechaNacimiento: new DateTime(1980, 6, 15),
                estado: true,
                especialidad: "Medicina General",
                numeroConsultorio: 101,
                aniosExperiencia: 10,
                sueldoBase: 1500m,
                numeroConsultas: 85,
                bonoPorConsulta: 10m
            );
            gestorMedicos.Insertar(mg1);

            // Médico General 2
            MedicoGeneral mg2 = new MedicoGeneral(
                idCodigo: "MG002",
                cedula: "0987654321",
                nombre: "Ana",
                apellido: "González",
                fechaNacimiento: new DateTime(1985, 3, 22),
                estado: true,
                especialidad: "Medicina General",
                numeroConsultorio: 102,
                aniosExperiencia: 7,
                sueldoBase: 1400m,
                numeroConsultas: 60,
                bonoPorConsulta: 10m
            );
            gestorMedicos.Insertar(mg2);

            // Médico Especialista 1
            MedicoEspecialista me1 = new MedicoEspecialista(
                idCodigo: "ME001",
                cedula: "1123456789",
                nombre: "Roberto",
                apellido: "Sánchez",
                fechaNacimiento: new DateTime(1975, 9, 10),
                estado: true,
                especialidad: "Cirugía General",
                numeroConsultorio: 201,
                aniosExperiencia: 15,
                sueldoBase: 2000m,
                numeroCirugias: 8,
                cirugiasExitosas: 7,
                comisionPorCirugia: 150m,
                bonoPorCirugiaExitosa: 200m
            );
            gestorMedicos.Insertar(me1);

            // Médico Especialista 2
            MedicoEspecialista me2 = new MedicoEspecialista(
                idCodigo: "ME002",
                cedula: "2234567890",
                nombre: "Patricia",
                apellido: "López",
                fechaNacimiento: new DateTime(1982, 12, 5),
                estado: true,
                especialidad: "Cardiología",
                numeroConsultorio: 202,
                aniosExperiencia: 12,
                sueldoBase: 1900m,
                numeroCirugias: 5,
                cirugiasExitosas: 5,
                comisionPorCirugia: 150m,
                bonoPorCirugiaExitosa: 200m
            );
            gestorMedicos.Insertar(me2);

            Console.WriteLine($"✅ Se cargaron {gestorMedicos.Cantidad} médicos.\n");

            // Mostrar menú interactivo
            MostrarMenu(gestorMedicos);
        }

        static void MostrarMenu(ListaMedicos gestorMedicos)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║       MENÚ PRINCIPAL                ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Listar todos los médicos         ║");
                Console.WriteLine("║ 2. Listar médicos generales         ║");
                Console.WriteLine("║ 3. Listar médicos especialistas     ║");
                Console.WriteLine("║ 4. Listar médicos activos           ║");
                Console.WriteLine("║ 5. Filtrar por especialidad         ║");
                Console.WriteLine("║ 6. Filtrar por experiencia          ║");
                Console.WriteLine("║ 7. Buscar médico por cédula         ║");
                Console.WriteLine("║ 8. Calcular sueldos y estadísticas  ║");
                Console.WriteLine("║ 9. Agrupar médicos por tipo         ║");
                Console.WriteLine("║ 10. Salir                           ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.Write("\nSelecciona una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarTodosMedicos(gestorMedicos);
                        break;
                    case "2":
                        ListarMedicosGenerales(gestorMedicos);
                        break;
                    case "3":
                        ListarMedicosEspecialistas(gestorMedicos);
                        break;
                    case "4":
                        ListarMedicosActivos(gestorMedicos);
                        break;
                    case "5":
                        FiltrarPorEspecialidad(gestorMedicos);
                        break;
                    case "6":
                        FiltrarPorExperiencia(gestorMedicos);
                        break;
                    case "7":
                        BuscarPorCedula(gestorMedicos);
                        break;
                    case "8":
                        CalcularSueldosYEstadisticas(gestorMedicos);
                        break;
                    case "9":
                        AgruparPorTipo(gestorMedicos);
                        break;
                    case "10":
                        continuar = false;
                        Console.WriteLine("\n👋 ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("\n❌ Opción inválida. Intenta de nuevo.");
                        break;
                }
            }
        }

        static void ListarTodosMedicos(ListaMedicos gestorMedicos)
        {
            Console.WriteLine("\n📋 === LISTADO DE TODOS LOS MÉDICOS ===\n");
            List<Medico> medicos = gestorMedicos.ListarTodos();

            if (medicos.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.");
                return;
            }

            foreach (var medico in medicos)
            {
                MostrarDetallesMedico(medico);
            }
        }

        static void ListarMedicosGenerales(ListaMedicos gestorMedicos)
        {
            Console.WriteLine("\n🏥 === LISTADO DE MÉDICOS GENERALES ===\n");
            List<Medico> medicos = gestorMedicos.ListarMedicosGenerales();

            if (medicos.Count == 0)
            {
                Console.WriteLine("No hay médicos generales registrados.");
                return;
            }

            foreach (var medico in medicos)
            {
                MostrarDetallesMedico(medico);
            }
        }

        static void ListarMedicosEspecialistas(ListaMedicos gestorMedicos)
        {
            Console.WriteLine("\n🏥 === LISTADO DE MÉDICOS ESPECIALISTAS ===\n");
            List<Medico> medicos = gestorMedicos.ListarMedicosEspecialistas();

            if (medicos.Count == 0)
            {
                Console.WriteLine("No hay médicos especialistas registrados.");
                return;
            }

            foreach (var medico in medicos)
            {
                MostrarDetaljesMedicoEspecialista((MedicoEspecialista)medico);
            }
        }

        static void ListarMedicosActivos(ListaMedicos gestorMedicos)
        {
            Console.WriteLine("\n✅ === LISTADO DE MÉDICOS ACTIVOS ===\n");
            List<Medico> medicos = gestorMedicos.ListarMedicosActivos();

            if (medicos.Count == 0)
            {
                Console.WriteLine("No hay médicos activos.");
                return;
            }

            foreach (var medico in medicos)
            {
                MostrarDetallesMedico(medico);
            }
        }

        static void FiltrarPorEspecialidad(ListaMedicos gestorMedicos)
        {
            Console.Write("\nIngresa la especialidad a buscar: ");
            string especialidad = Console.ReadLine();

            Console.WriteLine($"\n🔍 === MÉDICOS DE {especialidad.ToUpper()} ===\n");
            List<Medico> medicos = gestorMedicos.FiltrarPorEspecialidad(especialidad);

            if (medicos.Count == 0)
            {
                Console.WriteLine($"No hay médicos con la especialidad '{especialidad}'.");
                return;
            }

            foreach (var medico in medicos)
            {
                MostrarDetallesMedico(medico);
            }
        }

        static void FiltrarPorExperiencia(ListaMedicos gestorMedicos)
        {
            Console.Write("\nIngresa los años mínimos de experiencia: ");
            if (int.TryParse(Console.ReadLine(), out int anios))
            {
                Console.WriteLine($"\n⭐ === MÉDICOS CON {anios}+ AÑOS DE EXPERIENCIA ===\n");
                List<Medico> medicos = gestorMedicos.FiltrarPorExperiencia(anios);

                if (medicos.Count == 0)
                {
                    Console.WriteLine($"No hay médicos con {anios} o más años de experiencia.");
                    return;
                }

                foreach (var medico in medicos)
                {
                    MostrarDetallesMedico(medico);
                }
            }
            else
            {
                Console.WriteLine("❌ Ingresa un número válido.");
            }
        }

        static void BuscarPorCedula(ListaMedicos gestorMedicos)
        {
            Console.Write("\nIngresa la cédula a buscar: ");
            string cedula = Console.ReadLine();

            Medico medico = gestorMedicos.BuscarPorCedula(cedula);

            if (medico == null)
            {
                Console.WriteLine($"❌ No se encontró médico con cédula '{cedula}'.");
                return;
            }

            Console.WriteLine("\n🔍 === MÉDICO ENCONTRADO ===\n");
            MostrarDetallesMedico(medico);
        }

        static void CalcularSueldosYEstadisticas(ListaMedicos gestorMedicos)
        {
            Console.WriteLine("\n💰 === SUELDOS Y ESTADÍSTICAS ===\n");

            decimal totalSueldos = gestorMedicos.CalcularTotalSueldos();
            decimal promedioSueldos = gestorMedicos.CalcularPromedioSueldos();
            List<Medico> top3 = gestorMedicos.ObtenerTop3Sueldos();

            Console.WriteLine($"Total de sueldos a pagar: ${totalSueldos:F2}");
            Console.WriteLine($"Promedio de sueldos: ${promedioSueldos:F2}\n");

            Console.WriteLine("🏆 TOP 3 - Médicos con mayores sueldos:");
            int posicion = 1;
            foreach (var medico in top3)
            {
                Console.WriteLine($"{posicion}. {medico.ToString()}");
                Console.WriteLine($"   Sueldo Neto: ${medico.CalcularSueldo():F2}\n");
                posicion++;
            }
        }

        static void AgruparPorTipo(ListaMedicos gestorMedicos)
        {
            Console.WriteLine("\n📊 === AGRUPAMIENTO POR TIPO ===\n");

            Dictionary<string, int> agrupamiento = gestorMedicos.AgruparPorTipo();

            foreach (var tipo in agrupamiento)
            {
                Console.WriteLine($"{tipo.Key}: {tipo.Value} médico(s)");
            }
        }

        static void MostrarDetallesMedico(Medico medico)
        {
            Console.WriteLine($"ID: {medico.IdCodigo}");
            Console.WriteLine($"Nombre: {medico.Nombre} {medico.Apellido}");
            Console.WriteLine($"Cédula: {medico.Cedula}");
            Console.WriteLine($"Tipo: {medico.MostrarTipoMedico()}");
            Console.WriteLine($"Especialidad: {medico.Especialidad}");
            Console.WriteLine($"Consultorio: {medico.NumeroConsultorio}");
            Console.WriteLine($"Años de Experiencia: {medico.AniosExperiencia}");
            Console.WriteLine($"Sueldo Base: ${medico.SueldoBase:F2}");
            Console.WriteLine($"Sueldo Neto: ${medico.CalcularSueldo():F2}");
            Console.WriteLine($"Estado: {(medico.Estado ? "Activo" : "Inactivo")}");
            Console.WriteLine();
        }

        static void MostrarDetaljesMedicoEspecialista(MedicoEspecialista medico)
        {
            Console.WriteLine($"ID: {medico.IdCodigo}");
            Console.WriteLine($"Nombre: {medico.Nombre} {medico.Apellido}");
            Console.WriteLine($"Cédula: {medico.Cedula}");
            Console.WriteLine($"Tipo: {medico.MostrarTipoMedico()}");
            Console.WriteLine($"Especialidad: {medico.Especialidad}");
            Console.WriteLine($"Consultorio: {medico.NumeroConsultorio}");
            Console.WriteLine($"Años de Experiencia: {medico.AniosExperiencia}");
            Console.WriteLine($"Sueldo Base: ${medico.SueldoBase:F2}");
            Console.WriteLine($"Cirugías realizadas: {medico.NumeroCirugias}");
            Console.WriteLine($"Cirugías exitosas: {medico.CirugiasExitosas}");
            Console.WriteLine($"Sueldo Neto: ${medico.CalcularSueldo():F2}");
            Console.WriteLine($"Estado: {(medico.Estado ? "Activo" : "Inactivo")}");
            Console.WriteLine();
        }
    }
}
