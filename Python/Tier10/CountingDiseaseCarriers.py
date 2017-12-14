#http://rosalind.info/problems/afrq/
##import math
##
##data = map(float, open('C:\code\dataset.txt').read().split())
##p = map(lambda a: str(math.sqrt(a) * (1 - math.sqrt(a)) * 2 + a), data)
##
##print " ".join(p)




import scipy.special as ss
import numpy

data = list(map(int, open('C:\code\dataset.txt').read().split()))
alleles = data[0] * 2
dominant = data[1]
generations = data[2]
k = data[3]

p = dominant / alleles
q = 1 - p

hh = ss.binom(alleles, k)
q = (hh * (q**k) * (p**(alleles - k)))
p = 1 - q

print (q)
hh = ss.binom(alleles, k)
print(hh * (q**k) * (p**(alleles - k)))
##total_p = 0
##for k in range(0, k):
##    total_p += hh.pmf(k)
##
##print(total_p)
