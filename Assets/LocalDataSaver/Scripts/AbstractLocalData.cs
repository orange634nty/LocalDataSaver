namespace LocalDataSaver
{
    public abstract class AbstractLocalData<T> where T : new()
    {
        /// <summary>
        /// Try to load data from local storage
        /// if file is not exist, create new instance and return
        /// </summary>
        /// <returns></returns>
        public static T Load()
        {
            try
            {
                return LocalFileHandler<T>.Load();
            }
            catch
            {
                return new T();
            }
        }

        /// <summary>
        /// Save current data to local storage
        /// </summary>
        public void Save()
        {
            LocalFileHandler<T>.Save(this);
        }

        /// <summary>
        /// initialize data
        /// </summary>
        public static void InitializeData()
        {
            var data = new T();
            LocalFileHandler<T>.Save(data);
        }
    }
}
