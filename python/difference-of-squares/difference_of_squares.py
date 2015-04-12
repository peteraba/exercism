def square_of_sum(num):
	# https://www.google.de/search?q=sum+of+sequence
    seq_sum = num * (1 + num) / 2

    return seq_sum * seq_sum


def sum_of_squares(num):
	# http://www.trans4mind.com/personal_development/mathematics/series/sumNaturalSquares.htm
    return num * (num + 1) * (2 * num + 1) / 6

def difference(num):
    return square_of_sum(num) - sum_of_squares(num)

