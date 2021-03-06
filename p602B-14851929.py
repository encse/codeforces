﻿# Approximating a Constant Range
# http://codeforces.com/problemset/problem/602/B
import sys
n1 = map(int, sys.stdin.readline().split())
numbers = map(int, sys.stdin.readline().split())

lo = {}

max_len = 0
cur_len = 1
lo[numbers[0]] = 0
prev = numbers[0]
for i in xrange(1, len(numbers)):

	number = numbers[i]

	lo[number] = i
	if number == prev:
		cur_len += 1
	elif number == prev + 1:
		smaller =  lo[prev -1] if prev -1 in lo else -1
		bigger  =  lo[number + 1] if number + 1 in lo else -1
		begin = max(smaller, bigger) + 1
		cur_len = i - begin + 1
	elif number == prev - 1:
		bigger =  lo[prev + 1] if prev + 1 in lo else -1
		smaller  =  lo[number - 1] if number - 1 in lo else -1
		begin = max(smaller, bigger) + 1
		cur_len = i - begin + 1

	prev = number

	max_len = max(cur_len, max_len)
print max_len
		                   