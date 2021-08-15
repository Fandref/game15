using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.Classes
{
    public struct ResultItem
    {
        public int size;
        public ResultTime result;
        public ResultItem(int s, ResultTime r)
        {
            size = s;
            result = r;
        }
    }
    public class BestResults
    {
        private List<ResultItem> highscoreList;
        public BestResults()
        {
            highscoreList = new List<ResultItem>();
            LoadResult();
        }
        public void LoadResult()
        {
            if (File.Exists("fifteenhighscorelist.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ResultItem>));
                using (Stream reader = new FileStream("fifteenhighscorelist.xml", FileMode.Open))
                {
                    List<ResultItem> loadedData = (List<ResultItem>)serializer.Deserialize(reader);
                    this.highscoreList.Clear();
                    foreach (var item in loadedData)
                        this.highscoreList.Add(item);
                }
            }
            else
            {
                this.highscoreList.Add(new ResultItem(3, new ResultTime(0, 0, 0)));
                this.highscoreList.Add(new ResultItem(4, new ResultTime(0, 0, 0)));
                this.highscoreList.Add(new ResultItem(5, new ResultTime(0, 0, 0)));
            }
        }

        public void SetResult(int size, ResultTime result)
        {
            var index = highscoreList.FindIndex(highscore => highscore.size == size);
            highscoreList[index] = new ResultItem(size, result);

        }

        public ResultTime GetResult(int size)
        {
            var index = highscoreList.FindIndex(highscore => highscore.size == size);
            if (index != -1)
                return highscoreList[index].result;
            else
                return new ResultTime(0, 0, 0);


        }

        public List<ResultItem> GetResultList()
        {
            return highscoreList;
        }

        public void SaveResult()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ResultItem>));
            using (Stream writer = new FileStream("fifteenhighscorelist.xml", FileMode.Create))
            {
                serializer.Serialize(writer, this.highscoreList);
            }
        }

       
    }
}
