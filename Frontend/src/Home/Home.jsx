import React from 'react'
import Header from "../Dashboard/Header/Header.jsx";
import { motion } from "framer-motion";
import { BarChart2, ShoppingBag, Users, Zap } from 'lucide-react'
import Card from '../Dashboard/Card/Card';

export default function Home() {
  return (
    <div className="flex-1 overflow-auto relative z-10">
        <Header title="Dashboard" />
        <main className="max-w-7xl mx-auto py-6 px-4 lg:px-8">
            <motion.div
             className="grid grid-cols-1 gap-5 sm:grid-cols-2 lg:grid-cols-4 mb-8"
             initial={{ opacity: 0, y: 20 }}
             animate={{ opacity: 1, y: 0 }}
			  transition={{ duration: 1 }}
            >
          <Card name='Total Sales' icon={Zap} value='$12,345' color='#6366F1' />
					<Card name='New Users' icon={Users} value='1,234' color='#8B5CF6' />
					<Card name='Total Products' icon={ShoppingBag} value='567' color='#EC4899' />
					<Card name='Conversion Rate' icon={BarChart2} value='12.5%' color='#10B981' />
            </motion.div>
        </main>

    </div>
  )
}
