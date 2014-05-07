using System;
namespace AYJZ.Entities
{
    public class BaseEntitie
    {
        private int action = 1;
        private int priority = 2;
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        private ColumnCollection _columns;
        public ColumnCollection Column
        {
            get
            {
                if (_columns == null)
                    _columns = new ColumnCollection();
                return _columns;
            }
        }        
    }
}