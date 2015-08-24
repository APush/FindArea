private ushort Vichislenie_cikl_coda(ushort in_data, ushort Ederror, int bugbit1_add, int bugbit2_add)
        {
            ushort rk1_1 = Convert.ToUInt16(in_data << 8);// сдвиг 8 бит в начало 16 битного слова
            ushort bx, ax;// переменные для вычисления
            ushort back_connect = 36617;// генерирующий полином

            ax = rk1_1;

            for (int ecx = 0; ecx < 8; ecx++)
            {
                bx = ax;
                bx = Convert.ToUInt16(bx & 32768);

                if (bx == 0)
                    ax = Convert.ToUInt16(ax << 1);
                else
                {
                    ax = Convert.ToUInt16(ax ^ back_connect);
                    bx = ax;
                    bx = Convert.ToUInt16(bx & 32768);
                    if (bx != 0)
                    {
                        ax = Convert.ToUInt16(ax << 1);
                        ax = Convert.ToUInt16(ax + 2);
                    }
                    else
                    {
                        ax = Convert.ToUInt16(ax << 1);
                        ax = Convert.ToUInt16(ax + 1);
                    }
                }
            }

            if (bugbit1_add > 7 & bugbit1_add < 24)//внесение ошибки в последовательность циклического кода, где  bugbitN_add номер искажаемого бита
            {
                ax = Convert.ToUInt16(ax ^ (Ederror << bugbit1_add - 8));
            }

            if (bugbit2_add > 7 & bugbit2_add < 24)
            {
                ax = Convert.ToUInt16(ax ^ (Ederror << bugbit2_add - 8));
            }

            return ax;

        }
