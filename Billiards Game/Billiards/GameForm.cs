using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Billiards
{
    public partial class GameForm : Form
    {
        private Point _mouseLocation;

        float width = 870;
        float height = 506;

        float _ballDiametr = 30f;
        float _ballRadius = 15f;

        int _maxBallVelocity = 24;
        float _ballDumping = 0.94f;

        public List<Ball> _balls;
        private Ball _whiteBall;
        private bool _mouseDowm;

        private Rectangle[] _upBorderRects;
        private Rectangle[] _downBorderRects;
        private Rectangle _rightBorderRect;
        private Rectangle _leftBorderRect;

        private Vector[] _holesCenters;

        int Shot;
        bool wasShot = false;
        bool Hit1 = false;
        bool Hit2 = false;
        bool Bot = true;

        public GameForm(int Shot)
        {
            InitializeComponent();
            this.Shot = Shot;
            width = this.width - 30;
            height = this.height - 50;

            _upBorderRects = new Rectangle[] { upBorder1.Bounds, upBorder2.Bounds };
            Controls.Remove(upBorder1);
            Controls.Remove(upBorder2);

            _downBorderRects = new Rectangle[] { downBorder1.Bounds, downBorder2.Bounds };
            Controls.Remove(downBorder1);
            Controls.Remove(downBorder2);

            _rightBorderRect = rightBorder.Bounds;
            _leftBorderRect = leftBorder.Bounds;
            Controls.Remove(rightBorder);
            Controls.Remove(leftBorder);

            _holesCenters = new Vector[]
            {
               getControlCenter(hole1),
               getControlCenter(hole2),
               getControlCenter(hole3),
               getControlCenter(hole4),
               getControlCenter(hole5),
               getControlCenter(hole6),
            };

            Controls.Remove(hole1);
            Controls.Remove(hole2);
            Controls.Remove(hole3);
            Controls.Remove(hole4);
            Controls.Remove(hole5);
            Controls.Remove(hole6);

            _whiteBall = new Ball(Color.White, new Vector(getControlCenter(whileBall).X, getControlCenter(whileBall).Y, 0));

            _balls = new List<Ball>();
            _balls.Add(_whiteBall);
            _balls.Add(new Ball(Color.Black, new Vector(getControlCenter(blackBall).X, getControlCenter(blackBall).Y, 0)));
            _balls.Add(new Ball(Color.Yellow, new Vector(getControlCenter(yellowBall).X, getControlCenter(yellowBall).Y, 0)));
            _balls.Add(new Ball(Color.Pink, new Vector(getControlCenter(pinkBall).X, getControlCenter(pinkBall).Y, 0)));
            _balls.Add(new Ball(Color.Blue, new Vector(getControlCenter(blueBall).X, getControlCenter(blueBall).Y, 0)));
            _balls.Add(new Ball(Color.Red, new Vector(getControlCenter(redBall).X, getControlCenter(redBall).Y, 0)));

            Controls.Remove(whileBall);
            Controls.Remove(blackBall);
            Controls.Remove(yellowBall);
            Controls.Remove(pinkBall);
            Controls.Remove(blueBall);
            Controls.Remove(redBall);
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            DrawBall(e.Graphics);
            if (Shot == 1)
                Text = "Billiard (Ваш удар!)";
            else
                Text = "Billiard";
            
            if (_mouseDowm)
            {
                Point ball = new Point((int)_whiteBall.position.X, (int)_whiteBall.position.Y);

                Pen pen = new Pen(Color.White, 2f);
                e.Graphics.DrawLine(pen, ball, _mouseLocation);
                pen.Dispose();
            }
        }

        public void DrawBall(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black, 2);
            SolidBrush solidBrush = new SolidBrush(Color.White);

            float positionX = 0;
            float positionY = 0;
            RectangleF outerRect;

            foreach (Ball ball in _balls)
            {
                positionX = (float)ball.position.X - _ballRadius;
                positionY = (float)ball.position.Y - _ballRadius;
                outerRect = new RectangleF(positionX, positionY, _ballDiametr, _ballDiametr);

                solidBrush.Color = ball.color;
                g.DrawEllipse(blackPen, outerRect);
                g.FillEllipse(solidBrush, outerRect);
            }

            blackPen.Dispose();
            solidBrush.Dispose();
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (Bot)
            {
                _mouseDowm = true;
                _mouseLocation = e.Location;

                this.MouseMove += GameForm_MouseMove;
                this.MouseUp += GameForm_MouseUp;
            }
        }
        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (Bot)
                _mouseLocation = e.Location;
        }
        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (Bot)
            {
                _mouseDowm = false;
                this.MouseMove -= GameForm_MouseMove;
                this.MouseUp -= GameForm_MouseUp;

                Vector mouse = new Vector((double)_mouseLocation.X, (double)_mouseLocation.Y, 0);
                _whiteBall.velocity = (_whiteBall.position - mouse);
                wasShot = true;
                Hit1 = Hit2 = false;
            }
        }

        internal void UpdateWorld()
        {
            Bot = true;
            foreach (Ball ball in _balls)
            {
                if (ball.velocity.Length() > _maxBallVelocity)
                {
                    ball.velocity = ball.velocity.Unit() * _maxBallVelocity;
                }
                ball.position += ball.velocity;

                ball.velocity *= _ballDumping;
                if (ball.velocity.Length() < 0.1f) ball.velocity = Vector.zero;
                if (ball.velocity.Length() != 0) Bot = false;
            }
            //
            if (Bot && Shot == 2 && !wasShot)
            {
                Point Best = new Point();
                double bestL = double.MaxValue;
                bool Find = false;
                for (double r = 2.5; r <= _maxBallVelocity && !Find; r += 2.5)
                {
                    for (int a = 0; a < 360 && !Find; a += 4)
                    {

                        List<Ball> my = new List<Ball>();
                        Ball myWhite = new Ball(Color.White, new Vector());
                        foreach (Ball ball in _balls)
                        {
                            Ball bl = new Ball(ball.color, ball.position);
                            my.Add(bl);
                            if (bl.color == Color.White)
                                myWhite = bl;
                        }

                        double ang = a * Math.PI / 180;
                        int x = (int)(myWhite.position.X + r * Math.Cos(ang));
                        int y = (int)(myWhite.position.Y - r * Math.Sin(ang));
                        if (r == 2.5 && a == 0) Best = new Point(x, y);
                        Vector mouse = new Vector((double)x, (double)y, 0);
                        myWhite.velocity = (myWhite.position - mouse);
                        bool Bad = false;
                        bool VZ;
                        do
                        {
                            VZ = true;
                            foreach (Ball ball in my)
                            {
                                ball.position += ball.velocity;
                                ball.velocity *= _ballDumping;
                                if (ball.velocity.Length() < 0.1f) ball.velocity = Vector.zero;
                                if (ball.velocity.Length() != 0) VZ = false;
                            }
                            for (int i = 0; i < my.Count; i++)
                            {
                                Ball firstBall = my[i];
                                for (int j = i + 1; j < my.Count; j++)
                                {
                                    Ball secondBall = my[j];
                                    double dist = (firstBall.position - secondBall.position).Length();
                                    if (dist < _ballDiametr)
                                    {
                                        double offset = _ballDiametr - dist;
                                        Vector direction = (firstBall.position - secondBall.position).Unit();
                                        Vector forse = direction * offset;
                                        firstBall.position += forse;
                                        secondBall.position -= forse;
                                        firstBall.velocity += forse;
                                        secondBall.velocity -= forse;
                                    }
                                }
                            }
                            foreach (Ball ball in my)
                                updateBorderCollisions(ball);
                            foreach (Ball ball in my)
                                if (checkBallInHoles(ball))
                                {
                                    my.Remove(ball);
                                    // если забили белый шар
                                    if (ball == myWhite)
                                        Bad = true;
                                    //если забили чёрный шар 
                                    else
                                        if (ball.color == Color.Black)
                                        //и на поле остался только белый, то победа.
                                        if (my.Count == 1 && my[0].color == Color.White)
                                        {
                                            Best = new Point(x, y);
                                            Find = true;
                                        }
                                        //а если на поле остались ещё шары, кроме белого, то проигрыш
                                        else
                                            Bad = true;
                                    else
                                    {
                                        Best = new Point(x, y);
                                        Find = true;
                                    }
                                    break;
                                }
                        } while (!VZ && !Find && !Bad);
                        if (!Find && !Bad)
                        {
                            double minL = double.MaxValue;
                            foreach (Ball b in my)
                                if (b != myWhite && (b.color != Color.Black || my.Count == 2))
                                    foreach (Vector v in _holesCenters)
                                    {
                                        double dx = b.position.X - v.X;
                                        double dy = b.position.Y - v.Y;
                                        double l = dx * dx + dy * dy;
                                        if (l < minL) minL = l;
                                    }
                            if (minL < bestL)
                            {
                                bestL = minL;
                                Best = new Point(x, y);
                            }
                        }
                    }//a
                }//r
                MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, Best.X, Best.Y, 0);
                Form_MouseDown(this, e);
                GameForm_MouseUp(this, e);
                return;
            }
            //
            if (!Bot)
            {
                for (int i = 0; i < _balls.Count; i++)
                {
                    Ball firstBall = _balls[i];

                    for (int j = i + 1; j < _balls.Count; j++)
                    {
                        Ball secondBall = _balls[j];

                        double dist = (firstBall.position - secondBall.position).Length();
                        if (dist < _ballDiametr)
                        {
                            double offset = _ballDiametr - dist;
                            Vector direction = (firstBall.position - secondBall.position).Unit();
                            Vector forse = direction * offset;

                            firstBall.position += forse;
                            secondBall.position -= forse;

                            firstBall.velocity += forse;
                            secondBall.velocity -= forse;
                        }
                    }
                }


                foreach (Ball ball in _balls)
                {
                    updateBorderCollisions(ball);
                }

                foreach (Ball ball in _balls)
                {
                    if (checkBallInHoles(ball))
                    {
                        if (Shot == 1) Hit1 = true;
                        if (Shot == 2) Hit2 = true;
                        _balls.Remove(ball);
                        Refresh();

                        // если забили белый шар
                        if (ball == _whiteBall)
                        {
                            MessageBox.Show("Вы забили белый шар..\nИ проиграли!");
                            Close();
                        }
                        //если забили чёрный шар 
                        else if (ball.color == Color.Black)
                        {
                            //и на поле остался только белый, то победа.
                            if (_balls.Count == 1 && _balls[0].color == Color.White)
                            {
                                if (Shot == 2)
                                    MessageBox.Show("Увы!!!\nКомпьютер выиграл!!!");
                                else
                                    MessageBox.Show("ПОЗДРАВЛЯЕМ!!!\nВы выиграли партию!!!");
                                Close();
                            }
                            //а если на поле остались ещё шары, кроме белого, то проигрыш
                            else
                            {
                                MessageBox.Show("Чёрный шар должен быть забит белым в самую последнюю очередь.\nНо у вас ещё остались шары на поле. Вы проиграли.");
                                Close();
                            }
                        }
                        break;
                    }
                }
            }
            if (Bot && wasShot)
            {
                wasShot = false;
                if (Shot == 1 && !Hit1) Shot = 2;
                else
                    if (Shot == 2 && !Hit2) Shot = 1;
            }

        }
        //Обновление столкновения с границей
        private void updateBorderCollisions(Ball ball)
        {

            if (_rightBorderRect.Contains((int)(ball.position.X + _ballRadius), (int)ball.position.Y))
            {
                ball.velocity.X *= -1;
                ball.position.X = _rightBorderRect.X - _ballRadius;

            }

            if (_leftBorderRect.Contains((int)(ball.position.X - _ballRadius), (int)ball.position.Y))
            {
                ball.velocity.X *= -1;
                ball.position.X = _leftBorderRect.Right + _ballRadius;
            }


            foreach (Rectangle rect in _upBorderRects)
            {
                if (rect.Contains((int)ball.position.X, (int)(ball.position.Y - _ballRadius)))
                {
                    ball.velocity.Y *= -1;
                    ball.position.Y = rect.Bottom + _ballRadius;
                }
            }

            foreach (Rectangle rect in _downBorderRects)
            {
                if (rect.Contains((int)ball.position.X, (int)(ball.position.Y + _ballRadius)))
                {
                    ball.velocity.Y *= -1;
                    ball.position.Y = rect.Y - _ballRadius;
                }
            }
        }
        //Проверка луз
        private bool checkBallInHoles(Ball ball)
        {
            foreach (Vector v in _holesCenters)
            {
                if ((v - ball.position).Length() <= _ballRadius)
                {
                    System.Console.WriteLine("{ball.color} in hole!");
                    return true;
                }
            }

            return false;
        }
        private Vector getControlCenter(Control control)
        {
            double X = control.Location.X + control.Width * 0.5f;
            double Y = control.Location.Y + control.Height * 0.5f;
            return new Vector(X, Y, 0);
        }

        private void GameForm_Load(object sender, System.EventArgs e)
        {

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

    }
}
