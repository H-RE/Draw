﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineasWPF
{
    class Nodo
    {
        public event EventHandler PositionChanged;
        private Point _Position;

        public Nodo(Point position)
        {
            _Position = position;
        }
        public Nodo()
        {
            _Position = new Point();
        }
        protected virtual void OnPositionChanged()
        {
            PositionChanged?.Invoke(this, EventArgs.Empty);
        }
        public Point Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                OnPositionChanged();
            }
        }
    }
}
