﻿using Benefits.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Benefit.DataAccessLayer
{
	public class BenefitRepository : BaseService, IBenefitRepository
	{
		private string connectionString;

		public BenefitRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region CRUD
        /// <summary>
        /// Creates a new record for Benefit
        /// </summary>
        /// <param name="BenefitModel">BenefitModel object as params</param>
        /// <returns>Returns id of the Benefit</returns>
        public int Create(BenefitModel BenefitModel)
		{
			SqlConnection sqlConnection = new SqlConnection(connectionString);

			SqlCommand command = new SqlCommand();
			command.Connection = sqlConnection;
			string sqlQuery = String.Format("Insert into Benefit (name,age) Values('{0}', '{1}');" + "Select @@Identity", BenefitModel.Name, BenefitModel.Age);
			command.CommandText = sqlQuery;
			sqlConnection.Open();
			int num = Convert.ToInt32(command.ExecuteScalar());
			sqlConnection.Close();
			return num;
		}

		/// <summary>
		/// Gets all Benefit details as list of Benefits
		/// </summary>
		/// <returns>Returns List of BenefitModel</returns>
		public List<BenefitModel> GetAll()
		{
			List<BenefitModel> empList = new List<BenefitModel>();
			SqlConnection sqlConnection = new SqlConnection(connectionString);

			SqlCommand command = new SqlCommand();
			command.Connection = sqlConnection;
			string sqlQuery = String.Format("select id,name,age from Benefit;");
			command.CommandText = sqlQuery;
			sqlConnection.Open();

			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			sqlDataAdapter.Fill(dt);

			foreach (DataRow dr in dt.Rows)
			{
				empList.Add(new BenefitModel
				{
					Id = GetDBInt(dr["id"]),
					Age = GetDBInt(dr["age"]),
					Name = GetDBString(dr["name"].ToString())
				});
			}

			return empList;
		}

		/// <summary>
		/// Updates the Benefit for the given id
		/// </summary>
		/// <param name="BenefitModel">Benefit model object</param>
		/// <returns>Returns int if successfully updated</returns>
		public int Update(BenefitModel BenefitModel)
		{
			SqlConnection sqlConnection = new SqlConnection(connectionString);

			SqlCommand command = new SqlCommand();
			command.CommandText = string.Format("update Benefit set name='{0}', age={1} where id={2};", BenefitModel.Name, BenefitModel.Age, BenefitModel.Id);
			command.Connection = sqlConnection;

			sqlConnection.Open();
			int update = Convert.ToInt32(command.ExecuteScalar());
			sqlConnection.Close();
			return update;
		}

		/// <summary>
		/// Deletes the Benefit for the given id
		/// </summary>
		/// <param name="BenefitModel">BenefitModel object</param>
		/// <returns></returns>
		public int Delete(int id)
		{
			SqlConnection sqlConnection = new SqlConnection(connectionString);

			SqlCommand command = new SqlCommand();
			command.CommandText = string.Format("delete from Benefit where id={0};", id);
			command.Connection = sqlConnection;

			sqlConnection.Open();
			int update = Convert.ToInt32(command.ExecuteScalar());
			sqlConnection.Close();
			return update;
		}
		#endregion

		#region Get Benefit details
		/// <summary>
		/// Gets Benefit details for the given id
		/// </summary>
		/// <param name="BenefitModel">Benefit Model</param>
		/// <returns>Returns Benefit details</returns>
		public BenefitModel GetBenefit(int id)
		{
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			SqlCommand command = new SqlCommand();
			command.Connection = sqlConnection;
			command.CommandText = "select id,name,age from Benefit where id=@id;";
			command.Parameters.AddWithValue("@id", id);
			sqlConnection.Open();

			var model = new BenefitModel();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				model.Name = GetDBString(reader["name"]);
				model.Age = GetDBInt(reader["age"]);
			}

			return model;
		}
		#endregion

	}
}
