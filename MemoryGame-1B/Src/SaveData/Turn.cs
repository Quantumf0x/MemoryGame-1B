﻿using System;

namespace MemoryGame_1B.SaveData
{
    /// <summary>
    /// Who's turn is it
    /// </summary>
    [Flags]
    public enum Turn
    {
        /// <summary>
        /// Player 1
        /// </summary>
        Player1,

        /// <summary>
        /// Player 2
        /// </summary>
        Player2
    }
}