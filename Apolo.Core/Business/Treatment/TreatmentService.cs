﻿using Apolo.Core.Business.Common;
using Apolo.Core.Data;
using Apolo.Core.Model;
using Apolo.Core.Model.Treatment;
using Apolo.Core.Model.Treatment.Blueprints;
using Apolo.Core.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Apolo.Core.Business
{
    public class RoutineService
    {
        ApoloContext context = new ApoloContext();

        public OperationResult GetWorkDayById(int workDayId)
        {
            return new OperationResult { RequestedObject = context.WorkDays.SingleOrDefault(x => x.ID == workDayId) };
        }

        public OperationResult GetWorkWeekById(int workWeekId)
        {
            return new OperationResult { RequestedObject = context.WorkWeeks.SingleOrDefault(x => x.ID == workWeekId) };
        }

        public OperationResult GetWorkUnitById(int workUnitId)
        {
            return new OperationResult { RequestedObject = context.WorkUnits.SingleOrDefault(x => x.ID == workUnitId) };
        }

        public OperationResult CompleteWorkUnitById(int workUnitId, int finalScore, WorkUnitCompletion workUnitCompletion)
        {
            var workUnit = context.WorkUnits.SingleOrDefault(x => x.ID == workUnitId);

            if(workUnit != null)
            {
                workUnit.IsFinished = true;
                workUnit.FinalScore = finalScore;
                CommonUtil.CopyPropertiesTo(workUnitCompletion, workUnit);
                context.SaveChanges();
            }

            return new OperationResult();
        }

        public OperationResult UpdateWorkUnit(int workUnitId, string rationale, int durationInMinutes, string game, string difficulty)
        {
            var workUnit = context.WorkUnits.SingleOrDefault(x => x.ID == workUnitId);

            if (workUnit != null)
            {
                workUnit.DurationInMinutes = durationInMinutes;
                workUnit.Game = game;
                workUnit.Difficulty = difficulty;

                var workUnitEdition = new WorkUnitEdition
                {
                    WorkUnitID = workUnitId,
                    Rationale = rationale,
                    DateTime = DateTime.Now
                };

                workUnit.WorkUnitEditions.Add(workUnitEdition);

                context.SaveChanges();
            }

            return new OperationResult();
        }

        public OperationResult GetRoutinesByUsername(string username)
        {
            return new OperationResult { RequestedObject = context.Routines.Where( x => x.Patient.Username == username ).ToList() };
        }

        public OperationResult GetRoutinesByPatientId(int patientId)
        {
            return new OperationResult { RequestedObject = context.Routines.Where(x => x.Patient.ID == patientId).ToList() };
        }

        public OperationResult GetRoutineById(int routineId)
        {
            return new OperationResult { RequestedObject = context.Routines.SingleOrDefault( x => x.ID == routineId) };
        }

        public OperationResult GetWorkDayForToday(string username)
        {
            WorkDay workDayForToday;
            try
            {
                workDayForToday = context.WorkDays.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now)
                                    && x.WorkWeek.Routine.Patient.Username == username).ToList().First();
            }
            catch
            {
                workDayForToday = null;
            }

            return new OperationResult { RequestedObject = workDayForToday };
        }

        public OperationResult GetAllRoutineBlueprints()
        {
            return new OperationResult { RequestedObject = context.RoutineBlueprints.ToList() };
        }

        public OperationResult GetRoutineBlueprintById(int id)
        {
            return new OperationResult { RequestedObject = context.RoutineBlueprints.SingleOrDefault( x => x.ID == id) };
        }

        public OperationResult MakeRoutineFromBlueprint(OperationRequest operationRequest)
        {
            var operationResult = new OperationResult();
            var routineBlueprintID = (int)operationRequest.Parameters[Constants.Operation.BLUEPRINT_ID];
            var routineBlueprint = context.RoutineBlueprints.SingleOrDefault( x => x.ID == routineBlueprintID);

            var routine = new Routine
            {
                PatientID = (int)operationRequest.Parameters[Constants.Operation.PATIENT_ID],
                TherapistID = (int)operationRequest.Parameters[Constants.Operation.THERAPIST_ID],
                DurationInWeeks = routineBlueprint.DurationInWeeks,
                Goal = (string)operationRequest.Parameters[Constants.Operation.GOAL],
                Details = (string)operationRequest.Parameters[Constants.Operation.DETAILS],
                StartDate = (DateTime)operationRequest.Parameters[Constants.Operation.START_DATE]
            };

            for(int i = 0; i < routineBlueprint.WorkWeekBlueprints.Count; i++)
            {
                var workWeekBlueprint = routineBlueprint.WorkWeekBlueprints.ElementAt(i);
                var workWeek = new WorkWeek
                {
                    Number = i,
                    StartDate = routine.StartDate.AddDays(i*7 + i),
                    EndDate = routine.StartDate.AddDays(i*7 + 6),
                    Routine = routine
                };

                foreach(var workDayBlueprint in workWeekBlueprint.WorkDays)
                {
                    var workDay = new WorkDay
                    {
                        Date = workWeek.StartDate.AddDays(workDayBlueprint.Number),
                        WorkWeek = workWeek
                    };

                    foreach(var workUnitBlueprint in workDayBlueprint.WorkUnitBlueprints)
                    {
                        var workUnit = new WorkUnit
                        {
                            DurationInMinutes = workUnitBlueprint.DurationInMinutes,
                            Difficulty = workUnitBlueprint.Difficulty,
                            Game = workUnitBlueprint.Game,
                            WorkDay = workDay
                        };

                        workDay.WorkUnits.Add(workUnit);
                    }

                    workWeek.WorkDays.Add(workDay);
                }

                routine.WorkWeeks.Add(workWeek);
            }

            context.Routines.Add(routine);
            context.SaveChanges();

            operationResult.RequestedObject = routine;

            return operationResult;
        }

        public OperationResult DeleteRoutineById(int routineId)
        {
            var operationResult = new OperationResult();

            var routine = context.Routines.SingleOrDefault(x => x.ID == routineId);

            if(routine != null)
            {
                context.Routines.Remove(routine);
                context.SaveChanges();
            }

            return operationResult;
        }
    }
}