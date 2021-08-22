using System.Text;

namespace ConsolePrinter
{
    internal class FramePrinter
    {
        private readonly string _drawingBlock;
        private readonly int _height;
        private readonly int _width;
        private string _horizontalWall = string.Empty;
        private string _middleRow = string.Empty;
        private readonly StringBuilder _frame = new();

        public FramePrinter(string drawingBlock, int height, int width)
        {
            _drawingBlock = drawingBlock;
            _height = height;
            _width = width;
        }
        
        public StringBuilder GetFrame()
        {
            GetRowStrings();
            PrintRows();
            return _frame;
        }

        private void PrintRows()
        {
            _frame.AppendLine(_horizontalWall);
            for (int i = 0; i < _height - 2; i++)
            {
                _frame.AppendLine(_middleRow);
            }
            _frame.AppendLine(_horizontalWall);
        }

        private void GetRowStrings()
        {
            _middleRow += _drawingBlock;
            for (int i = 0; i < _width; i++)
            {
                _horizontalWall += _drawingBlock;
                if (i > 0 && i < _width - 1)
                    _middleRow += GetDrawingBlockEmptySpace();
            }
            _middleRow += _drawingBlock;
        }

        private string GetDrawingBlockEmptySpace()
        {
            var result = string.Empty;
            for (int i = 0; i < _drawingBlock.Length; i++)
            {
                result += " ";
            }
            return result;
        }
    }
}