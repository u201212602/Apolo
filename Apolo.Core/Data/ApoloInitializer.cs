using Apolo.Core.Model;
using Apolo.Core.Model.Security;
using Apolo.Core.Model.Treatment;
using Apolo.Core.Util;
using System;
using System.Linq;
using System.Collections.Generic;
using Apolo.Core.Model.Treatment.Blueprints;

namespace Apolo.Core.Data
{
    public class ApoloInitializer : System.Data.Entity.CreateDatabaseIfNotExists<ApoloContext>
    {
        protected override void Seed(ApoloContext context)
        {
            #region Users
            context.Users.Add(GetAdminUser());
            
            context.Users.Add(GetTherapistUser());
            foreach(var patient in GetPatientUsers())
            {
                context.Users.Add(patient);
            }
            context.SaveChanges();
            
            #endregion

            
            #region Routines
            foreach (var routine in GetRoutines(context))
            {
                context.Routines.Add(routine);
            }
            context.SaveChanges();
            #endregion
            

            #region Routine Blueprints
            foreach (var routineBlueprint in GetRoutineBlueprints())
            {
                context.RoutineBlueprints.Add(routineBlueprint);
            }
            context.SaveChanges();
            #endregion
        }

        private User GetAdminUser()
        {
            Guid guid = new Guid();
            byte[] avatar = null;
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\jsandoval.png");
            }
            catch(Exception ex)
            {
                avatar = null;
            }
            User user = new User
            {
                FirstName = "José",
                LastName = "Sandoval",
                Birthday = new DateTime(1993, 6, 20),
                Username = "jsandoval",
                Password = SecurityUtil.GenerateSaltedHash("6H8M5kSQVWPgRRBqIsmK", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.ADMINISTRATOR,
                Avatar = avatar
            };
            return user;
        }

        private User GetTherapistUser()
        {
            Guid guid = new Guid();
            byte[] avatar = null;
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\fcaceres.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            User user = new User
            {
                FirstName = "Franco",
                LastName = "Cáceres",
                Birthday = new DateTime(1994, 10, 24),
                Username = "fcaceres",
                Password = SecurityUtil.GenerateSaltedHash("fcaceres", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.THERAPIST,
                Avatar = avatar
            };
            return user;
        }

        private List<User> GetPatientUsers()
        {
            List<User> patients = new List<User>();

            #region Sheila
            Guid guid = new Guid();
            byte[] avatar;
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\sccahua.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            User user = new User
            {
                FirstName = "Sheila",
                LastName = "Ccahua",
                Birthday = new DateTime(1992, 09, 14),
                Username = "sccahua",
                Password = SecurityUtil.GenerateSaltedHash("sccahua", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Tanya
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\tluna.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Tanya",
                LastName = "Luna",
                Birthday = new DateTime(1995, 1, 14),
                Username = "tluna",
                Password = SecurityUtil.GenerateSaltedHash("tluna", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Marcos
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\mdiaz.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Marcos",
                LastName = "Diaz",
                Birthday = new DateTime(1955, 5, 20),
                Username = "mdiaz",
                Password = SecurityUtil.GenerateSaltedHash("mdiaz", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Andrea
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\apereira.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Andrea",
                LastName = "Pereira",
                Birthday = new DateTime(1995, 2, 11),
                Username = "apereira",
                Password = SecurityUtil.GenerateSaltedHash("apereira", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Carlos
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\cmendoza.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Carlos",
                LastName = "Mendoza",
                Birthday = new DateTime(1991, 4, 12),
                Username = "cmendoza",
                Password = SecurityUtil.GenerateSaltedHash("cmendoza", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Diana
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\dcriollo.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Diana",
                LastName = "Criollo",
                Birthday = new DateTime(1965, 5, 28),
                Username = "dcriollo",
                Password = SecurityUtil.GenerateSaltedHash("dcriollo", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Claudio
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\chulerig.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Claudio",
                LastName = "Hulerig",
                Birthday = new DateTime(1980, 4, 12),
                Username = "chulerig",
                Password = SecurityUtil.GenerateSaltedHash("chulerig", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Luis Renato
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\lrodriguez.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Luis Renato",
                LastName = "Rodriguez",
                Birthday = new DateTime(1990, 7, 9),
                Username = "lrodriguez",
                Password = SecurityUtil.GenerateSaltedHash("lrodriguez", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Cynthia
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\csanchez.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Cynthia",
                LastName = "Sanchez",
                Birthday = new DateTime(1985, 1, 18),
                Username = "csanchez",
                Password = SecurityUtil.GenerateSaltedHash("csanchez", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.HEMORRAGHIC
            };
            patients.Add(user);
            #endregion

            #region Milagros
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\mrojas.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Milagros",
                LastName = "Rojas",
                Birthday = new DateTime(1970, 11, 5),
                Username = "mrojas",
                Password = SecurityUtil.GenerateSaltedHash("mrojas", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.FEMALE,
                Condition = Constants.Conditions.ISCHEMIC
            };
            patients.Add(user);
            #endregion

            #region Andres
            guid = new Guid();
            try
            {
                avatar = System.IO.File.ReadAllBytes(@".\temp\aherrera.png");
            }
            catch (Exception ex)
            {
                avatar = null;
            }
            user = new User
            {
                FirstName = "Andres",
                LastName = "Herrera",
                Birthday = new DateTime(1960, 3, 15),
                Username = "aherrera",
                Password = SecurityUtil.GenerateSaltedHash("aherrera", guid.ToString()),
                Salt = guid,
                Role = Constants.Roles.PATIENT,
                Avatar = avatar,
                Gender = Constants.Genders.MALE
            };
            patients.Add(user);
            #endregion

            return patients;
        }

        private List<Routine> GetRoutines(ApoloContext context)
        {
            List<Routine> routines = new List<Routine>();

            #region Marcos
            #region Routine 1
            Routine routine = new Routine
            {
                StartDate = DateTime.Now.AddDays(0),
                DurationInWeeks = 4,
                Patient = context.Users.SingleOrDefault( x => x.Username == "mdiaz"),
                Therapist = context.Users.SingleOrDefault( x => x.Username == "fcaceres")
            };

            for(int i = 0; i < routine.DurationInWeeks; i++)
            {
                WorkWeek workWeek = new WorkWeek()
                {
                    StartDate = routine.StartDate.AddDays(i * 7 + i),
                    EndDate = routine.StartDate.AddDays((i + 1) * 7 - 1),
                    Number = i,
                    Routine = routine
                };
                
                for(int k = 0; k < 7; k++)
                {
                    WorkDay workDay = new WorkDay()
                    {
                        Date = workWeek.StartDate.AddDays(k),
                        Number = k,
                        WorkWeek = workWeek
                    };

                    WorkUnit pongWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        DurationInMinutes = 1,
                        Number = 0,
                        Game = Constants.Games.PONG,
                        Difficulty = Constants.Games.Difficulty.EASY
                    };

                    WorkUnit tetrisWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        DurationInMinutes = 1,
                        Number = 1,
                        Game = Constants.Games.TETRIS,
                        Difficulty = Constants.Games.Difficulty.MEDIUM
                    };

                    WorkUnit invadersWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        DurationInMinutes = 1,
                        Number = 2,
                        Game = Constants.Games.INVADERS,
                        Difficulty = Constants.Games.Difficulty.HARD
                    };

                    WorkUnit jumperWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        DurationInMinutes = 1,
                        Number = 3,
                        Game = Constants.Games.JUMPER,
                        Difficulty = Constants.Games.Difficulty.HARD
                    };

                    workDay.WorkUnits.Add(pongWorkUnit);
                    workDay.WorkUnits.Add(tetrisWorkUnit);
                    workDay.WorkUnits.Add(invadersWorkUnit);
                    workDay.WorkUnits.Add(jumperWorkUnit);

                    workWeek.WorkDays.Add(workDay);
                }

                routine.WorkWeeks.Add(workWeek);
            }

            routines.Add(routine);
            #endregion

            #region Routine 2
            routine = new Routine
            {
                StartDate = DateTime.Now.AddDays(-60),
                DurationInWeeks = 3,
                Patient = context.Users.SingleOrDefault(x => x.Username == "mdiaz"),
                Therapist = context.Users.SingleOrDefault(x => x.Username == "fcaceres")
            };

            for (int i = 0; i < routine.DurationInWeeks; i++)
            {
                WorkWeek workWeek = new WorkWeek()
                {
                    StartDate = routine.StartDate.AddDays(i * 7 + i),
                    EndDate = routine.StartDate.AddDays((i + 1) * 7 - 1),
                    Number = i + 1,
                    Routine = routine
                };

                for (int k = 0; k < 5; k++)
                {
                    WorkDay workDay = new WorkDay()
                    {
                        Date = workWeek.StartDate.AddDays(k),
                        Number = k,
                        WorkWeek = workWeek
                    };

                    WorkUnit pongWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        Number = 0,
                        DurationInMinutes = 5,
                        Game = Constants.Games.PONG,
                        Difficulty = Constants.Games.Difficulty.EASY,
                        IsFinished = true,
                        FinalScore = 100*k
                    };

                    WorkUnit tetrisWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        Number = 1,
                        DurationInMinutes = 4,
                        Game = Constants.Games.TETRIS,
                        Difficulty = Constants.Games.Difficulty.MEDIUM,
                        IsFinished = true,
                        FinalScore = 100 * k
                    };

                    WorkUnit invadersWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        Number = 2,
                        DurationInMinutes = 3,
                        Game = Constants.Games.INVADERS,
                        Difficulty = Constants.Games.Difficulty.HARD,
                        IsFinished = true,
                        FinalScore = 100 * k
                    };

                    WorkUnit jumperWorkUnit = new WorkUnit()
                    {
                        WorkDay = workDay,
                        Number = 3,
                        DurationInMinutes = 3,
                        Game = Constants.Games.JUMPER,
                        Difficulty = Constants.Games.Difficulty.HARD,
                        IsFinished = true,
                        FinalScore = 100 * k
                    };

                    SetRandomDataForWorkUnit(pongWorkUnit);
                    SetRandomDataForWorkUnit(tetrisWorkUnit);
                    SetRandomDataForWorkUnit(invadersWorkUnit);
                    SetRandomDataForWorkUnit(jumperWorkUnit);

                    workDay.WorkUnits.Add(pongWorkUnit);
                    workDay.WorkUnits.Add(tetrisWorkUnit);
                    workDay.WorkUnits.Add(invadersWorkUnit);
                    workDay.WorkUnits.Add(jumperWorkUnit);

                    workWeek.WorkDays.Add(workDay);
                }

                routine.WorkWeeks.Add(workWeek);
            }

            routines.Add(routine);
            #endregion
            #endregion

            return routines;
        }

        private List<RoutineBlueprint> GetRoutineBlueprints()
        {
            var routineBlueprints = new List<RoutineBlueprint>();

            #region Routine Blueprint 1
            var routineBlueprint = new RoutineBlueprint
            {
                Category = Constants.Routines.Categories.INTERMEDIATE,
                DurationInWeeks = 6,
                Name = "Rutina Intermedia 1",
                Description = "Rutina para pacientes en etapas de recuperación intermedia"
            };

            for(int i = 0; i < routineBlueprint.DurationInWeeks; i++)
            {
                var workWeekBlueprint = new WorkWeekBlueprint
                {
                    DurationInDays = 5,
                    Number = i,
                    RoutineBlueprint = routineBlueprint
                };

                for(int k = 0; k < workWeekBlueprint.DurationInDays; k++)
                {
                    var workDayBlueprint = new WorkDayBlueprint
                    {
                        Number = k,
                        WorkWeekBlueprint = workWeekBlueprint
                    };

                    var workUnitBlueprint1 = new WorkUnitBlueprint
                    {
                        Game = Constants.Games.TETRIS,
                        Number = 0,
                        Difficulty = Constants.Games.Difficulty.MEDIUM,
                        DurationInMinutes = 5,
                        WorkDayBlueprint = workDayBlueprint
                    };

                    var workUnitBlueprint2 = new WorkUnitBlueprint
                    {
                        Game = Constants.Games.PONG,
                        Number = 1,
                        Difficulty = Constants.Games.Difficulty.HARD,
                        DurationInMinutes = 2,
                        WorkDayBlueprint = workDayBlueprint
                    };

                    workDayBlueprint.WorkUnitBlueprints.Add(workUnitBlueprint1);
                    workDayBlueprint.WorkUnitBlueprints.Add(workUnitBlueprint2);

                    workWeekBlueprint.WorkDays.Add(workDayBlueprint);
                }

                routineBlueprint.WorkWeekBlueprints.Add(workWeekBlueprint);
            }
            routineBlueprints.Add(routineBlueprint);
            #endregion
            #region Routine Blueprint 2
            routineBlueprint = new RoutineBlueprint
            {
                Category = Constants.Routines.Categories.BASIC,
                DurationInWeeks = 6,
                Name = "Rutina de Incepción 1",
                Description = "Rutina básica para pacientes en las etapas iniciales de recuperación"
            };

            for (int i = 0; i < routineBlueprint.DurationInWeeks; i++)
            {
                var workWeekBlueprint = new WorkWeekBlueprint
                {
                    DurationInDays = 3,
                    Number = i,
                    RoutineBlueprint = routineBlueprint
                };

                for (int k = 0; k < workWeekBlueprint.DurationInDays; k++)
                {
                    var workDayBlueprint = new WorkDayBlueprint
                    {
                        Number = k,
                        WorkWeekBlueprint = workWeekBlueprint
                    };

                    var workUnitBlueprint1 = new WorkUnitBlueprint
                    {
                        Game = Constants.Games.TETRIS,
                        Number = 0,
                        Difficulty = Constants.Games.Difficulty.EASY,
                        DurationInMinutes = 1,
                        WorkDayBlueprint = workDayBlueprint
                    };

                    var workUnitBlueprint2 = new WorkUnitBlueprint
                    {
                        Game = Constants.Games.PONG,
                        Number = 1,
                        Difficulty = Constants.Games.Difficulty.EASY,
                        DurationInMinutes = 1,
                        WorkDayBlueprint = workDayBlueprint
                    };

                    var workUnitBlueprint3 = new WorkUnitBlueprint
                    {
                        Game = Constants.Games.INVADERS,
                        Number = 3,
                        Difficulty = Constants.Games.Difficulty.EASY,
                        DurationInMinutes = 1,
                        WorkDayBlueprint = workDayBlueprint
                    };

                    var workUnitBlueprint4 = new WorkUnitBlueprint
                    {
                        Game = Constants.Games.JUMPER,
                        Number = 4,
                        Difficulty = Constants.Games.Difficulty.EASY,
                        DurationInMinutes = 1,
                        WorkDayBlueprint = workDayBlueprint
                    };

                    workDayBlueprint.WorkUnitBlueprints.Add(workUnitBlueprint1);
                    workDayBlueprint.WorkUnitBlueprints.Add(workUnitBlueprint2);
                    workDayBlueprint.WorkUnitBlueprints.Add(workUnitBlueprint3);
                    workDayBlueprint.WorkUnitBlueprints.Add(workUnitBlueprint4);

                    workWeekBlueprint.WorkDays.Add(workDayBlueprint);
                }

                routineBlueprint.WorkWeekBlueprints.Add(workWeekBlueprint);
            }
            routineBlueprints.Add(routineBlueprint);
            #endregion

            return routineBlueprints;
        }

        private Random r = new Random((int)DateTime.Now.Ticks);

        private void SetRandomDataForWorkUnit(WorkUnit workUnit)
        {

            workUnit.AvgAccelY = r.Next(500);
            workUnit.AvgRomY = r.Next(500);
            workUnit.AvgPod0 = r.Next(500);
            workUnit.AvgPod1 = r.Next(500);
            workUnit.AvgPod2 = r.Next(500);
            workUnit.AvgPod3 = r.Next(500);
            workUnit.AvgPod4 = r.Next(500);
            workUnit.AvgPod5 = r.Next(500);
            workUnit.AvgPod6 = r.Next(500);
            workUnit.AvgPod7 = r.Next(500);
        }
    }
}
