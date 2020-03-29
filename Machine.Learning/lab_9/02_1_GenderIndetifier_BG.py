# В българския език имената на жените обикновено завършват на двете гласни: а и я.
# Например: Яна, Ива, Мария, Иванова, Ковачева и т.н.
# Имената на мъжете завършват обикновено на съгласна: Иван, Драган, Петкан, Драгомир, Иванов, Коларов и т.н.
# Напишете  функция,  която  според  името  на  човекс  българско  име,  извежда информация, от какъв пол е.
import string


def gender_bender(input_str: string):
    if input_str[-1].lower() in 'аят':
        return 'Женски'

    if input_str[-1].lower() in 'бвгджзклмнопрсфхчшщц':
        return 'Мъжки'

    return 'Неопределен';


print('Полът на това име вероятно е: ' + gender_bender(input()))