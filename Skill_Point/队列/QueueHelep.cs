using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Skill_Point.队列
{


    public class QueueHelep<T>
    {
        private ConcurrentQueue<T> documentQueue = new ConcurrentQueue<T>();
        public void AddDocument(T t)
        {
            documentQueue.Enqueue(t);
        }


        //public T GetDocument(T t)
        //{
           
        //        if (this.IsDocumentAvailable)
        //    return documentQueue.; 
        //}

        public bool IsDocumentAvailable
        {
            get
            {
                lock (this)
                {
                    return documentQueue.Count > 0;
                }

            }
        }
    }

    //存储在队列中的元素是Document类型
    public class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }

    //DocumentManager类是Queue<Document>外面的一层。用来如何将文档添加到队列和从队列中获取文档
    public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();

        //因为多个线程访问DocumentManager类，所以用lock语句锁定对队列的访问

        public void AddDocument(Document doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public Document GetDocument()
        {
            Document doc = null;
            lock (this)
            {
                if (this.IsDocumentAvailable)
                    doc = documentQueue.Dequeue();
            }
            return doc;
        }

        public bool IsDocumentAvailable
        {
            get
            {
                lock (this)
                {
                    return documentQueue.Count > 0;
                }

            }
        }
    }

    //使用ProcessDocuments类在一个单独的任务中读取和删除队列中的文档。
    public class ProcessDocuments
    {
        //能从外部访问的唯一方法是Start()方法
        //在Start()中，实例化一个新任务。创建一个ProcessDocuments对象，调用ProcessDocuments的Run()方法
        public static void Start(DocumentManager dm)
        {
            Task.Factory.StartNew(new ProcessDocuments(dm).Run);
        }

        protected ProcessDocuments(DocumentManager dm)
        {
            if (dm == null)
                throw new ArgumentNullException("dm");
            documentManager = dm;
        }

        private DocumentManager documentManager;

        //定义一个无限循环，使用DocumentManager类的IsDocumentAvailable属性确定队列中是否还有文档。
        protected void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    if (doc != null)
                        Console.WriteLine("Processing document {0}", doc.Title);
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }
}
