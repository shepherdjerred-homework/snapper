using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Data.Sqlite;

namespace snapper {
    class SqliteStore : Store {
        public SqliteStore() {
            InitializeDatabase();
        }

        public static void InitializeDatabase() {
            using (SqliteConnection db = new SqliteConnection("Filename=snapper.db")) {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS snaps " +
                                      "(id int, title text, content text)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public override List<Snap> GetSnaps() {
            List<Snap> snaps = new List<Snap>();

            using (SqliteConnection db = new SqliteConnection("Filename=snapper.db")) {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * from snaps", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read()) {
                    Snap snap = new Snap(
                        query.GetInt32(0),
                        query.GetString(1),
                        query.GetString(2)
                    );
                    snaps.Add(snap);
                }

                db.Close();
            }

            return snaps;
        }

        public override void SaveSnap(Snap snap) {
            using (SqliteConnection db = new SqliteConnection("Filename=snapper.db")) {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO snaps VALUES (@id, @title, @content);";
                insertCommand.Parameters.AddWithValue("@id", snap.Id);
                insertCommand.Parameters.AddWithValue("@title", snap.Title);
                insertCommand.Parameters.AddWithValue("@content", snap.Content);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public override void UpdateSnap(Snap snap) {
            using (SqliteConnection db = new SqliteConnection("Filename=snapper.db")) {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "UPDATE snaps SET title = @title, content = @content WHERE id = @id;";
                insertCommand.Parameters.AddWithValue("@title", snap.Title);
                insertCommand.Parameters.AddWithValue("@content", snap.Content);
                insertCommand.Parameters.AddWithValue("@id", snap.Id);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public override void DeleteSnap(Snap snap) {
            using (SqliteConnection db = new SqliteConnection("Filename=snapper.db")) {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "DELETE FROM snaps WHERE id = @id;";
                insertCommand.Parameters.AddWithValue("@id", snap.Id);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
    }
}